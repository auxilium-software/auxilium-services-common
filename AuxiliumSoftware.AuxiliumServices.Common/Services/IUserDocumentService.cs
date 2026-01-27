using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels;

namespace AuxiliumSoftware.AuxiliumServices.Common.Services.Interfaces
{
    public interface IUserDocumentService
    {
        Task<UserEntityModel?> GetDocumentAsync(Guid userId);
        Task SaveDocumentAsync(UserEntityModel userDoc);



        Task<List<UserAdditionalPropertyEntityModel>> GetAdditionalPropertiesAsync(Guid userId);
        Task SaveAdditionalPropertyAsync(Guid userId, string additionalPropertyName, string additionalPropertyContent);
        Task DeleteAdditionalPropertyAsync(Guid userId, Guid additionalPropertyId);



        bool CheckUserAccess(Guid userId, UserEntityModel currentUser);

    }
}
