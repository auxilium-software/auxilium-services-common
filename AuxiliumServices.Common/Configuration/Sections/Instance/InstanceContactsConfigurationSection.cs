using AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Instance.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Instance
{
    public class InstanceContactsConfigurationSection
    {
        public required InstanceContactsFirstPointOfContactConfigurationSection FirstPointOfContact { get; set; }
        public required InstanceContactsGeneralConfigurationSection Maintainer { get; set; }
        public required InstanceContactsGeneralConfigurationSection Operator { get; set; }
        public required InstanceContactsGeneralConfigurationSection GeneralEnquiries { get; set; }
    }
}
