using AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Policies.LoggingPolicy;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Policies
{
    public class LoggingPolicyConfigurationSection
    {
        public required LoggingSecurityPolicyConfigurationSection Security { get; set; }
        public required LoggingEntityActionsPolicyConfigurationSection EntityActions { get; set; }
    }
}
