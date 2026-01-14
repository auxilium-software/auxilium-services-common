using AuxiliumServices.Common.Configuration.Sections.Instance;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumServices.Common.Configuration.Sections
{
    public class InstanceConfigurationSection
    {
        public required string FQDN { get; set; }
        public required InstanceBrandingConfigurationSection Branding { get; set; }
        public required InstanceContactsConfigurationSection Contacts { get; set; }
        public required InstanceDefaultsConfigurationSection Defaults { get; set; }
        public required InstanceNavigationConfigurationSection Navigation { get; set; }
    }
}
