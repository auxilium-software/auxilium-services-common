using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.SMTP
{
    public class SMTPFromConfigurationSection
    {
        public string Address { get; set; } = null!;
        public string Name { get; set; } = null!;



        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Address)) throw new InvalidOperationException("Configuration value 'SMTP->From->Address' is missing.");
            if (string.IsNullOrWhiteSpace(Name))    throw new InvalidOperationException("Configuration value 'SMTP->From->Name' is missing.");
        }
    }
}
