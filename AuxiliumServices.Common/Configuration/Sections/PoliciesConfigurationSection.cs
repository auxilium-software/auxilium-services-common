using AuxiliumServices.Common.Configuration.Sections.Policies;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumServices.Common.Configuration.Sections
{
    public class PoliciesConfigurationSection
    {
        public required PasswordPolicyConfigurationSection PasswordPolicy { get; set; }
    }
}
