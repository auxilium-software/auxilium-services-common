using AuxiliumSoftware.AuxiliumServices.Common.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Services
{
    public interface IPermissionService
    {
        bool Can(Guid userId, DatabaseObjectTypeEnum resource, CasbinPolicyActionTypeEnum action);
        bool CanPerformActionUponCase(Guid currentUserId, Guid targetCaseId, CasbinPolicyActionTypeEnum action);
        bool CanPerformActionUponUser(Guid currentUserId, Guid targetUserId, CasbinPolicyActionTypeEnum action);
    }
}
