using AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.API.CORS;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections
{
    public class APIConfigurationSection
    {
        public List<string> AvailableFrom { get; set; } = null!;
        public string AvailableAt { get; set; } = null!;
        public APICORSConfigurationSection CORS { get; set; } = null!;
        


        public void Validate()
        {
            if (AvailableFrom == null || AvailableFrom.Count == 0)  throw new InvalidOperationException("Configuration value 'API->AvailableFrom' is missing or empty.");
            if (string.IsNullOrWhiteSpace(AvailableAt))             throw new InvalidOperationException("Configuration value 'API->AvailableAt' is missing.");
            if (CORS == null)                                       throw new InvalidOperationException("Configuration section 'API->CORS' is missing.");

            CORS.Validate();
        }
    }
}
