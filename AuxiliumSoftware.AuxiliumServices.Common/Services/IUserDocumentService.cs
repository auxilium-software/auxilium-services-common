using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels;
using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators;

namespace AuxiliumSoftware.AuxiliumServices.Common.Services
{
    public interface IUserDocumentService
    {
        Task<UserEntityModel?> GetDocumentAsync(Guid userId);
        Task SaveDocumentAsync(UserEntityModel userDoc);



        Task<List<UserAdditionalPropertyEntityModel>> GetAdditionalPropertiesAsync(Guid userId);
        Task SaveAdditionalPropertyAsync(UserEntityModel currentUser, Guid userId, string additionalPropertyOriginalName, string additionalPropertyUrlSlug, string content, string contentType);
        Task DeleteAdditionalPropertyAsync(Guid userId, Guid additionalPropertyId);



        bool CheckUserAccess(Guid userId, UserEntityModel currentUser);



        void WriteToAuditLog(
            UserEntityModel currentUser,
            UserEntityModel targetUser, UserEntityTypeEnum entityType, Guid entityId,
            AuditLogActionTypeEnum actionType,
            string? propertyName = null, string? oldValue = null, string? newValue = null
        );
    }
}
