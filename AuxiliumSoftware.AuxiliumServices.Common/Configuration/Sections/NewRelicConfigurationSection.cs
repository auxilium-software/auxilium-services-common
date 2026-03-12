using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections
{
    public class NewRelicConfigurationSection
    {
        public bool UseNewRelic { get; set; } = false;
        public string Key { get; set; } = null!;
        


        public void Validate()
        {
            // UseNewRelic
            if (string.IsNullOrWhiteSpace(Key))     throw new InvalidOperationException("Configuration value 'NewRelic->Key' is missing.");
        }
    }
}
