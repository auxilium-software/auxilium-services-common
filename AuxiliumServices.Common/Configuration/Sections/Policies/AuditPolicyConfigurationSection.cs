using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumServices.Common.Configuration.Sections.Policies
{
    public class AuditPolicyConfigurationSection
    {
        public required bool LogSuccessfulLogins { get; set; }
        public required bool LogFailedLogins { get; set; }
        public required bool LogPasswordChanges { get; set; }
        public required bool LogAccountLockouts { get; set; }
        public required bool LogPermissionChanges { get; set; }
    }
}
