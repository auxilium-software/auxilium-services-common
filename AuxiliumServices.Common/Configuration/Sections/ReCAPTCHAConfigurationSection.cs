using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumServices.Common.Configuration.Sections
{
    public class ReCAPTCHAConfigurationSection
    {
        public required string SiteKey { get; set; }
        public required string SecretKey { get; set; }
        public required float ScoreThreshold { get; set; }
    }
}
