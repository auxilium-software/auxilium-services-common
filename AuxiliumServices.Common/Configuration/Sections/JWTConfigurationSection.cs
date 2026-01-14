using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumServices.Common.Configuration.Sections
{
    public class JWTConfigurationSection
    {
        public required string SecretKey { get; set; }
        public required string Algorithm { get; set; }
        public required int AccessTokenExpirationInMinutes { get; set; }
        public required int RefreshTokenExpirationInDays { get; set; }
        public required string ValidIssuer { get; set; }
        public required string ValidAudience { get; set; }
    }
}
