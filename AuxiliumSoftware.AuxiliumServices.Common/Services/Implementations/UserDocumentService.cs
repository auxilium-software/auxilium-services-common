using AuxiliumSoftware.AuxiliumServices.Common.Configuration;
using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework;
using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels;
using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators;
using AuxiliumSoftware.AuxiliumServices.Common.Enumerators;
using AuxiliumSoftware.AuxiliumServices.Common.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace AuxiliumSoftware.AuxiliumServices.Common.Services.Implementations;

public class UserDocumentService : IUserDocumentService
{
    private readonly ConfigurationStructure _configuration;
    private readonly AuxiliumDbContext _db;
    private readonly ILogger<UserDocumentService> _logger;

    public UserDocumentService(
        IConfiguration configuration,
        AuxiliumDbContext db,
        ILogger<UserDocumentService> logger
    )
    {
        this._configuration = configuration.Get<ConfigurationStructure>();
        _db = db;
        _logger = logger;
    }

    #region ========================= USER OPERATIONS =========================
    public async Task<UserEntityModel?> GetDocumentAsync(Guid userId)
    {
        try
        {
            return await _db.Users
                .Include(u => u.AdditionalProperties)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get user {UserId}", userId);
            return null;
        }
    }

    public async Task SaveDocumentAsync(UserEntityModel userDoc)
    {
        try
        {
            userDoc.LastUpdatedAt = DateTime.UtcNow;

            var entry = _db.Entry(userDoc);
            if (entry.State == EntityState.Detached)
            {
                _db.Users.Update(userDoc);
            }

            await _db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to save user {UserId}", userDoc.Id);
            throw;
        }
    }
    #endregion
    #region ========================= ADDITIONAL PROPERTIES =========================
    public async Task<List<UserAdditionalPropertyEntityModel>> GetAdditionalPropertiesAsync(Guid caseId)
    {
        try
        {
            return await _db.UserAdditionalProperties
                .Where(a => a.UserId == caseId)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get additional properties for case {CaseId}", caseId);
            throw;
        }
    }

    public async Task SaveAdditionalPropertyAsync(
        UserEntityModel currentUser,
        Guid userId,
        string additionalPropertyName,
        string additionalPropertyContent,
        string? contentType = null
    )
    {
        try
        {
            // check if the property exists
            var existing = await _db.UserAdditionalProperties
                .FirstOrDefaultAsync(a => a.UserId == userId && a.Name == additionalPropertyName);

            if (existing != null)
            {
                throw new Exception($"Additional property {additionalPropertyName} already exists for user {userId}");
            }

            var newProperty = new UserAdditionalPropertyEntityModel
            {
                Id = UUIDUtilities.GenerateV5(DatabaseObjectType.UserAdditionalProperty),
                UserId = userId,
                ContentType = contentType ?? "text/plain",
                CreatedBy = currentUser.Id,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow,
                LastUpdatedBy = Guid.Empty,
                Name = additionalPropertyName,
                Content = additionalPropertyContent,
            };

            _db.UserAdditionalProperties.Add(newProperty);

            // update the LastUpdatedAt timestamp for the user
            var userEntity = await _db.Users.FindAsync(userId);
            if (userEntity != null)
            {
                userEntity.LastUpdatedAt = DateTime.UtcNow;
            }

            await _db.SaveChangesAsync();

            _logger.LogInformation("Saved property {AdditionalPropertyName} for user {UserId}", additionalPropertyName, userId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to save property {AdditionalPropertyName} for user {UserId}", additionalPropertyName, userId);
            throw;
        }
    }

    public async Task DeleteAdditionalPropertyAsync(Guid userId, Guid additionalPropertyId)
    {
        try
        {
            var property = await _db.UserAdditionalProperties
                .FirstOrDefaultAsync(a => a.UserId == userId && a.Id == additionalPropertyId);

            if (property != null)
            {
                _db.UserAdditionalProperties.Remove(property);

                // update the LastUpdatedAt timestamp for the case
                var userEntity = await _db.Users.FindAsync(userId);
                if (userEntity != null)
                {
                    userEntity.LastUpdatedAt = DateTime.UtcNow;
                }

                await _db.SaveChangesAsync();

                _logger.LogInformation("Deleted property {AdditionalPropertyId} from case {;}", additionalPropertyId, userId);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete property {AdditionalPropertyId} from case {;}", additionalPropertyId, userId);
            throw;
        }
    }
    #endregion
    #region ========================= PERMISSION CHECKS =========================
    public bool CheckUserAccess(Guid userId, UserEntityModel currentUser)
    {
        try
        {
            // admins can access absolutely everything
            if (currentUser.IsAdmin) return true;

            // users can access their own data
            if (currentUser.Id == userId) return true;

            // case workers can view other users (for assigning to cases)
            if (currentUser.IsCaseWorker) return true;

            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to check access for user {UserId}", userId);
            return false;
        }
    }
    #endregion
    #region ========================= AUDIT LOGGING OPERATIONS =========================
    /// <summary>
    /// This method writes an entry to the audit log for case-related actions.
    /// IT WILL NOT SAVE CHANGES TO THE DATABASE - CALLER MUST COMMIT CHANGES.
    /// </summary>
    /// <param name="currentUser">The currently logged in User // the User that did the Action.</param>
    /// <param name="targetCase">The Case the Action that is being Audit Logged is for.</param>
    /// <param name="entityType">The type of Case-related Entity that is being Audit Logged.</param>
    /// <param name="entityId">The unique identifier for the Case-related Entity.</param>
    /// <param name="actionType">The type of Action that is being Audit Logged.</param>
    /// <param name="propertyName">This value is MANDATORY when actionType is set to `Modification` - it specifies the target Property that has been Modified.</param>
    /// <param name="oldValue">This value is MANDATORY when actionType is set to `Modification` - it specifies the old value of the Property that has been Modified.</param>
    /// <param name="newValue">This value is MANDATORY when actionType is set to `Modification` - it specifies the new value of the Property that has been Modified.</param>
    public void WriteToAuditLog(
        UserEntityModel currentUser,
        UserEntityModel targetUser, UserEntityTypeEnum entityType, Guid entityId,
        AuditLogActionTypeEnum actionType,
        string? propertyName = null, string? oldValue = null, string? newValue = null
    )
    {
        // verification
        switch (entityType)
        {
            case UserEntityTypeEnum.User:
                if (actionType == AuditLogActionTypeEnum.Creation && !this._configuration.Policies.LoggingPolicy.EntityActions.Users.LogCreations) return;
                if (actionType == AuditLogActionTypeEnum.Modification && !this._configuration.Policies.LoggingPolicy.EntityActions.Users.LogModifications) return;
                if (actionType == AuditLogActionTypeEnum.Deletion && !this._configuration.Policies.LoggingPolicy.EntityActions.Users.LogDeletions) return;
                break;
            case UserEntityTypeEnum.User_AdditionalProperty:
                if (actionType == AuditLogActionTypeEnum.Creation && !this._configuration.Policies.LoggingPolicy.EntityActions.UserAdditionalProperties.LogCreations) return;
                if (actionType == AuditLogActionTypeEnum.Modification && !this._configuration.Policies.LoggingPolicy.EntityActions.UserAdditionalProperties.LogModifications) return;
                if (actionType == AuditLogActionTypeEnum.Deletion && !this._configuration.Policies.LoggingPolicy.EntityActions.UserAdditionalProperties.LogDeletions) return;
                break;
            case UserEntityTypeEnum.User_File:
                if (actionType == AuditLogActionTypeEnum.Upload && !this._configuration.Policies.LoggingPolicy.EntityActions.UserFiles.LogUploads) return;
                if (actionType == AuditLogActionTypeEnum.View && !this._configuration.Policies.LoggingPolicy.EntityActions.UserFiles.LogViews) return;
                if (actionType == AuditLogActionTypeEnum.Deletion && !this._configuration.Policies.LoggingPolicy.EntityActions.UserFiles.LogDeletions) return;
                break;
        }

        // actually logging
        var logEntry = new LogUserModificationEventEntityModel
        {
            Id = UUIDUtilities.GenerateV5(DatabaseObjectType.LogUserModificationEvent),
            CreatedAt = DateTime.UtcNow,
            CreatedBy = currentUser.Id,
            UserId = targetUser.Id,
            EntityType = entityType,
            EntityId = entityId,
            Action = actionType,
            PropertyName = actionType == AuditLogActionTypeEnum.Modification ? propertyName : null,
            PreviousValue = actionType == AuditLogActionTypeEnum.Modification ? oldValue : null,
            NewValue = actionType == AuditLogActionTypeEnum.Modification ? newValue : null,
        };

        // commiting
        _db.Log_UserModificationEvents.Add(logEntry);
    }
    #endregion
}
