using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Instance.Contacts.FirstPointOfContact
{
    public class InstanceContactsFirstPointOfContactPhoneConfigurationSection
    {
        public required string Number { get; set; }
        public required string OpeningHours { get; set; }
    }
}
