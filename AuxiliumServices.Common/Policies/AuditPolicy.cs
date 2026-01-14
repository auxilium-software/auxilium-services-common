using AuxiliumServices.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumServices.Common.Policies
{
    public static class AuditPolicy
    {
        public static bool LogSuccessfulLogins(ConfigurationStructure configuration) => configuration.Policies.AuditPolicy.LogSuccessfulLogins;
        public static bool LogFailedLogins(ConfigurationStructure configuration) => configuration.Policies.AuditPolicy.LogFailedLogins;
        public static bool LogPasswordChanges(ConfigurationStructure configuration) => configuration.Policies.AuditPolicy.LogPasswordChanges;
        public static bool LogAccountLockouts(ConfigurationStructure configuration) => configuration.Policies.AuditPolicy.LogAccountLockouts;
        public static bool LogPermissionChanges(ConfigurationStructure configuration) => configuration.Policies.AuditPolicy.LogPermissionChanges;
    }
}
