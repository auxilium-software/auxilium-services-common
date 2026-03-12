using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections
{
    public class APIConfigurationSection
    {
        public required List<string> AvailableFrom { get; set; }
        public required string AvailableAt { get; set; }
        public required APIConfigurationSection CORS { get; set; }
    }
}
