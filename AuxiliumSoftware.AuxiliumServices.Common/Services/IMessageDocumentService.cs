using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels;

namespace AuxiliumSoftware.AuxiliumServices.Common.Services.Interfaces
{
    public interface IMessageDocumentService
    {
        Task<CaseMessageEntityModel> CreateMessageAsync(
                Guid caseId,
                string subject,
                string content,
                Guid senderId,
                bool isUrgent = false);

        Task<CaseMessageEntityModel?> GetMessageAsync(Guid messageId);
        Task<List<CaseMessageEntityModel>> GetMessagesForCaseAsync(Guid caseId);
        Task MarkAsReadAsync(Guid messageId, Guid userId);
        Task<List<Guid>> GetReadByUsersAsync(Guid messageId);
        Task<Dictionary<Guid, DateTime>> GetReadByDetailsAsync(Guid messageId);
        Task<bool> IsReadByAsync(Guid messageId, Guid userId);
        Task DeleteMessageAsync(Guid messageId);
        Task<bool> CheckUserAccessAsync(Guid messageId, UserEntityModel currentUser);
    }
}
