using AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Databases;
using AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration
{
    public class ConfigurationStructure
    {
        public required DatabasesConfigurationSection Databases { get; set; }
        public required ReCAPTCHAConfigurationSection ReCAPTCHA { get; set; }
        public required JWTConfigurationSection JWT { get; set; }
        public required APIConfigurationSection API { get; set; }
        public required FileSystemConfigurationSection FileSystem { get; set; }
        public required Argon2ConfigurationSection Argon2 { get; set; }
        public required MfaConfigurationSection MFA { get; set; }
        public required InstanceConfigurationSection Instance { get; set; }
        public required NewRelicConfigurationSection NewRelic { get; set; }
        public required DevelopmentConfigurationSection Development { get; set; }
    }
}
