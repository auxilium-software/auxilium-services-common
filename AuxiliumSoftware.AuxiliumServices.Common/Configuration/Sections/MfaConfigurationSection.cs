using AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.MFA;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections
{
    public class MfaConfigurationSection
    {
        public required TotpConfigurationSection TOTP { get; set; }
    }
}
