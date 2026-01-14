using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Policies.PasswordPolicy
{
    public class PasswordPolicyRequirementsConfigurationSection
    {
        public required bool AtLeastOneUppercaseCharacter { get; set; }
        public required bool AtLeastOneLowercaseCharacter { get; set; }
        public required bool AtLeastOneNumericCharacter { get; set; }
        public required bool AtLeastOneSpecialCharacter { get; set; }
    }
}
