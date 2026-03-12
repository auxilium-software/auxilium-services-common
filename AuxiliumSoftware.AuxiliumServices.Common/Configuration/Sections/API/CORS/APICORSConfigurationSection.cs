using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.API.CORS
{
    public class APICORSConfigurationSection
    {
        public List<string> AllowedOrigins { get; set; } = null!;
        public List<string> AllowedHosts { get; set; } = null!;
        


        public void Validate()
        {
            if (AllowedOrigins == null || AllowedOrigins.Count == 0)    throw new InvalidOperationException("Configuration value 'API->CORS->AllowedOrigins' is missing or empty.");
            if (AllowedHosts == null || AllowedHosts.Count == 0)        throw new InvalidOperationException("Configuration value 'API->CORS->AllowedHosts' is missing or empty.");
        }
    }
}
