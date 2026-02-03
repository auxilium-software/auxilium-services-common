using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Policies.LoggingPolicy
{
    public class LoggingSecurityPolicyConfigurationSection
    {
        public required bool LogSuccessfulLogins { get; set; }
        public required bool LogIncorrectPasswordLoginAttempts { get; set; }
        public required bool LogIncorrectEmailAddressLoginAttempts { get; set; }
        public required bool LogPasswordChanges { get; set; }
    }
}
