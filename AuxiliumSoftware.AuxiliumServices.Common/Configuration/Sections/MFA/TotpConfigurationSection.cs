using AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.MFA.Totp;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.MFA
{
    public class TotpConfigurationSection
    {
        public required string Issuer { get; set; }
        public required RecoveryCode RecoveryCode { get; set; }
    }
}
