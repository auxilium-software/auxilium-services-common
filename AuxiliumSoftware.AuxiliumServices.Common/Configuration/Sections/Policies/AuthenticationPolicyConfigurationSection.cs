using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Policies
{
    public class AuthenticationPolicyConfigurationSection
    {
        public required bool PreventPasswordReuse { get; set; }
    }
}
