using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections
{
    public class APIConfigurationSection
    {
        public required string Protocol { get; set; }
        public required string AvailableFrom { get; set; }
        public required int Port { get; set; }
        public required string AvailableAt { get; set; }
        public required APIConfigurationSection CORS { get; set; }
    }
}
