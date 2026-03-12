using AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.MFA;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections
{
    public class MfaConfigurationSection
    {
        public TotpConfigurationSection TOTP { get; set; } = null!;
        


        public void Validate()
        {
            if (TOTP == null)   throw new InvalidOperationException("Configuration section 'MFA->TOTP' is missing.");

            TOTP.Validate();
        }
    }
}
