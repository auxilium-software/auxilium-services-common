using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.MFA.Totp
{
    public class RecoveryCode
    {
        public required int GroupSize { get; set; }
        public required int GroupCount { get; set; }
        public required string CharacterSet { get; set; }
    }
}
