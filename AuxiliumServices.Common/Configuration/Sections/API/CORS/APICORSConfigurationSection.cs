using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace AuxiliumServices.Common.Configuration.Sections.API.CORS
{
    public class APICORSConfigurationSection
    {
        public required List<string> AllowedOrigins { get; set; }
        public required List<string> AllowedHosts { get; set; }
    }
}
