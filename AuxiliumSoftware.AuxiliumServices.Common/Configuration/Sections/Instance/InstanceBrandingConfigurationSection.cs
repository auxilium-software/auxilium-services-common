using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Instance
{
    public class InstanceBrandingConfigurationSection
    {
        public required string LogoRelativePath { get; set; }
        public required string LogoContrastRelativePath { get; set; }
        public required string Name { get; set; }
    }
}
