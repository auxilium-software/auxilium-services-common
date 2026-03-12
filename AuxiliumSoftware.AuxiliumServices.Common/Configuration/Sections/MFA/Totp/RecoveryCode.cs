using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.MFA.Totp
{
    public class RecoveryCode
    {
        public int GroupSize { get; set; } = 0;
        public int GroupCount { get; set; } = 0;
        


        public void Validate()
        {
            if (GroupSize <= 0)     throw new InvalidOperationException("Configuration section 'MFA->TOTP->RecoveryCode->GroupSize' is missing or invalid.");
            if (GroupCount <= 0)    throw new InvalidOperationException("Configuration section 'MFA->TOTP->RecoveryCode->GroupCount' is missing or invalid.");
        }
    }
}
