using AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Databases;
using AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration
{
    public class ConfigurationStructure
    {
        public DatabasesConfigurationSection Databases { get; set; } = null!;
        public ReCAPTCHAConfigurationSection ReCAPTCHA { get; set; } = null!;
        public JWTConfigurationSection JWT { get; set; } = null!;
        public APIConfigurationSection API { get; set; } = null!;
        public SMTPConfigurationSection SMTP { get; set; } = null!;
        public FileSystemConfigurationSection FileSystem { get; set; } = null!;
        public Argon2ConfigurationSection Argon2 { get; set; } = null!;
        // instance config
        //public NewRelicConfigurationSection NewRelic { get; set; } = null!;
        public DevelopmentConfigurationSection Development { get; set; } = null!;



        public void Validate()
        {
            if (Databases is null)      throw new InvalidOperationException("Configuration section 'Databases' is missing.");
            if (ReCAPTCHA is null)      throw new InvalidOperationException("Configuration section 'ReCAPTCHA' is missing.");
            if (JWT is null)            throw new InvalidOperationException("Configuration section 'JWT' is missing.");
            if (API is null)            throw new InvalidOperationException("Configuration section 'API' is missing.");
            if (SMTP is null)           throw new InvalidOperationException("Configuration section 'SMTP' is missing.");
            if (FileSystem is null)     throw new InvalidOperationException("Configuration section 'FileSystem' is missing.");
            if (Argon2 is null)         throw new InvalidOperationException("Configuration section 'Argon2' is missing.");
            // instance config
            //if (NewRelic is null)       throw new InvalidOperationException("Configuration section 'NewRelic' is missing.");
            if (Development is null)    throw new InvalidOperationException("Configuration section 'Development' is missing.");

            Databases.Validate();
            ReCAPTCHA.Validate();
            JWT.Validate();
            API.Validate();
            SMTP.Validate();
            FileSystem.Validate();
            Argon2.Validate();
            // instance config
            //NewRelic.Validate();
            Development.Validate();
        }
    }
}
