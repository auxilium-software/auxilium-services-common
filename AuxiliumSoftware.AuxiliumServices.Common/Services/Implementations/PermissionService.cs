using AuxiliumSoftware.AuxiliumServices.Common.Enumerators;
using AuxiliumSoftware.AuxiliumServices.Common.Extensions;
using Casbin;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Services.Implementations
{
    public class PermissionService : IPermissionService
    {
        private readonly IEnforcer _enforcer;

        public PermissionService(IEnforcer enforcer)
        {
            _enforcer = enforcer;
        }

        public bool Can(Guid userId, DatabaseObjectTypeEnum resource, CasbinPolicyActionTypeEnum action)
            => _enforcer.Enforce(userId.ToString(), resource.ToPolicyString(), action.ToPolicyString());

        public bool CanPerformActionUponCase(Guid currentUserId, Guid targetCaseId, CasbinPolicyActionTypeEnum action)
        {
            string objectTypeString = DatabaseObjectTypeEnum.Case.ToPolicyString();

            return _enforcer.Enforce(currentUserId.ToString(),  $"{objectTypeString}:{targetCaseId}",   action.ToPolicyString())
                || _enforcer.Enforce(currentUserId.ToString(),  $"{objectTypeString}:*",                action.ToPolicyString());
        }
        public bool CanPerformActionUponUser(Guid currentUserId, Guid targetUserId, CasbinPolicyActionTypeEnum action)
        {
            string objectTypeString = DatabaseObjectTypeEnum.User.ToPolicyString();

            return _enforcer.Enforce(currentUserId.ToString(),  $"{objectTypeString}:{targetUserId}",   action.ToPolicyString())
                || _enforcer.Enforce(currentUserId.ToString(),  $"{objectTypeString}:*",                action.ToPolicyString());
        }
    }
}
