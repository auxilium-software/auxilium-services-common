using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels;

namespace AuxiliumSoftware.AuxiliumServices.Common.Services
{
    public interface IAuthorisationService
    {
        bool IsAdmin(UserEntityModel user);
        bool IsCaseWorker(UserEntityModel user);
        bool CanViewCase(UserEntityModel user, CaseEntityModel caseDoc);
        bool CanModifyCase(UserEntityModel user, CaseEntityModel caseDoc);
        bool CanDeleteCase(UserEntityModel user, CaseEntityModel caseDoc);
        bool CanManageCaseProperties(UserEntityModel user, CaseEntityModel caseDoc);
        bool CanManageTodos(UserEntityModel user, CaseEntityModel caseDoc);
        bool CanViewUser(UserEntityModel currentUser, Guid targetUserId);
        bool CanModifyUser(UserEntityModel currentUser, Guid targetUserId);
    }
}
