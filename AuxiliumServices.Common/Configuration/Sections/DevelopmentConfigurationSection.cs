using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumServices.Common.Configuration.Sections
{
    public class DevelopmentConfigurationSection
    {
        public required bool DisableReCAPTCHA { get; set; }
        public required bool PHPAcceptSelfSignedCertificatesForAPI { get; set; }
    }
}
