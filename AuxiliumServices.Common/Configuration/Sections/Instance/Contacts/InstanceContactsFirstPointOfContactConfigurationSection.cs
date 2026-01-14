using AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Instance.Contacts.FirstPointOfContact;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Instance.Contacts
{
    public class InstanceContactsFirstPointOfContactConfigurationSection
    {
        public required string EmailAddress { get; set; }
        public required InstanceContactsFirstPointOfContactPhoneConfigurationSection Phone { get; set; }
        public required InstanceContactsFirstPointOfContactPhoneConfigurationSection Text { get; set; }
    }
}
