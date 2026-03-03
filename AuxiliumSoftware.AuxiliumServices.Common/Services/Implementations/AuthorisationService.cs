using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels;
using AuxiliumSoftware.AuxiliumServices.Common.Services;

namespace AuxiliumSoftware.AuxiliumServices.Common.Services.Implementations
{
    public class AuthorisationService : IAuthorisationService
    {
        public bool IsAdmin(UserEntityModel user)
        {
            return user.IsAdministrator;
        }

        public bool IsCaseWorker(UserEntityModel user)
        {
            return user.IsCaseWorker || user.IsAdministrator;
        }

        public bool CanViewCase(UserEntityModel user, CaseEntityModel caseDoc)
        {
            // admins can very everything
            if (user.IsAdministrator) return true;

            // workers and clients can view their assigned cases
            var isWorker = caseDoc.Workers?.Any(w => w.UserId == user.Id) ?? false;
            var isClient = caseDoc.Clients?.Any(c => c.UserId == user.Id) ?? false;

            return isWorker || isClient;
        }

        public bool CanModifyCase(UserEntityModel user, CaseEntityModel caseDoc)
        {
            // admins can modify anything
            if (user.IsAdministrator) return true;

            // workers can modify their cases
            return caseDoc.Workers?.Any(w => w.UserId == user.Id) ?? false;
        }

        public bool CanDeleteCase(UserEntityModel user, CaseEntityModel caseDoc)
        {
            // same permissions as to modify
            return CanModifyCase(user, caseDoc);
        }

        public bool CanManageCaseProperties(UserEntityModel user, CaseEntityModel caseDoc)
        {
            // same permissions as to modify
            return CanModifyCase(user, caseDoc);
        }

        public bool CanManageTodos(UserEntityModel user, CaseEntityModel caseDoc)
        {
            // same permissions as to modify
            return CanModifyCase(user, caseDoc);
        }

        public bool CanViewUser(UserEntityModel currentUser, Guid targetUserId)
        {
            // admins can view anyone
            if (currentUser.IsAdministrator) return true;

            // users can view themselves
            return currentUser.Id == targetUserId;
        }

        public bool CanModifyUser(UserEntityModel currentUser, Guid targetUserId)
        {
            // only admins can modify other users
            if (currentUser.IsAdministrator) return true;

            // users can modify themselves
            return currentUser.Id == targetUserId;
        }
    }
}
