using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumServices.Common.Configuration.Sections
{
    public class NewRelicConfigurationSection
    {
        public required bool UseNewRelic { get; set; }
        public required string Key { get; set; }
    }
}
