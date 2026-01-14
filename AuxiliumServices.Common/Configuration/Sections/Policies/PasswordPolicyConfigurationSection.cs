using System;
using System.Collections.Generic;
using System.Text;
using AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Policies.PasswordPolicy;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Policies
{
    public class PasswordPolicyConfigurationSection
    {
        public required int MinimumLength { get; set; }
        public required PasswordPolicyRequirementsConfigurationSection Requirements { get; set; }
    }
}
