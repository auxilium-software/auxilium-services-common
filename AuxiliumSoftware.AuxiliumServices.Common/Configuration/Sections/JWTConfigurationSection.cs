using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections
{
    public class JWTConfigurationSection
    {
        public string SecretKey { get; set; } = null!;
        public string Algorithm { get; set; } = null!;
        public int MfaTokenExpirationInSeconds { get; set; } = 0;
        public int AccessTokenExpirationInMinutes { get; set; } = 0;
        public int RefreshTokenExpirationInDays { get; set; } = 0;
        public string ValidIssuer { get; set; } = null!;
        public string ValidAudiencePrefix { get; set; } = null!;
        


        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(SecretKey))           throw new InvalidOperationException("Configuration value 'JWT->SecretKey' is missing.");
            if (string.IsNullOrWhiteSpace(Algorithm))           throw new InvalidOperationException("Configuration value 'JWT->Algorithm' is missing.");
            if (MfaTokenExpirationInSeconds <= 0)               throw new InvalidOperationException("Configuration value 'JWT->MfaTokenExpirationInSeconds' is missing or invalid.");
            if (AccessTokenExpirationInMinutes <= 0)            throw new InvalidOperationException("Configuration value 'JWT->AccessTokenExpirationInMinutes' is missing or invalid.");
            if (RefreshTokenExpirationInDays <= 0)              throw new InvalidOperationException("Configuration value 'JWT->RefreshTokenExpirationInDays' is missing or invalid.");
            if (string.IsNullOrWhiteSpace(ValidIssuer))         throw new InvalidOperationException("Configuration value 'JWT->ValidIssuer' is missing.");
            if (string.IsNullOrWhiteSpace(ValidAudiencePrefix)) throw new InvalidOperationException("Configuration value 'JWT->ValidAudiencePrefix' is missing.");
        }
    }
}
