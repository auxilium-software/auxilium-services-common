using AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.MFA.Totp;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.MFA
{
    public class TotpConfigurationSection
    {
        public string Issuer { get; set; } = null!;
        public RecoveryCode RecoveryCode { get; set; } = null!;
        


        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Issuer))  throw new InvalidOperationException("Configuration value 'MFA->TOTP->Issuer' is missing.");
            if (RecoveryCode == null)               throw new InvalidOperationException("Configuration section 'MFA->TOTP->RecoveryCode' is missing.");

            RecoveryCode.Validate();
        }
    }
}
