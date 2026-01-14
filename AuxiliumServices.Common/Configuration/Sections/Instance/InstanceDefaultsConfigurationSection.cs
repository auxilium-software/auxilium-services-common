using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumServices.Common.Configuration.Sections.Instance
{
    public class InstanceDefaultsConfigurationSection
    {
        public required string TimeZone { get; set; }
        public required string Language { get; set; }
    }
}
