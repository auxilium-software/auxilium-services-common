using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumServices.Common.Configuration.Sections.Instance.Contacts
{
    public class InstanceContactsGeneralConfigurationSection
    {
        public required string Name { get; set; }
        public required string EmailAddress { get; set; }
    }
}
