using AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Policies;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections
{
    public class PoliciesConfigurationSection
    {
        public required PasswordPolicyConfigurationSection PasswordPolicy { get; set; }
        public required AccountLockoutPolicyConfigurationSection AccountLockoutPolicy { get; set; }
        public required AuthenticationPolicyConfigurationSection AuthenticationPolicy { get; set; }
        public required LoggingPolicyConfigurationSection LoggingPolicy { get; set; }
    }
}
