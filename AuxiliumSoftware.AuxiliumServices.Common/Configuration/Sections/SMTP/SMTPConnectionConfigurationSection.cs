using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.SMTP
{
    public class SMTPConnectionConfigurationSection
    {
        public string Host { get; set; } = null!;
        public int Port { get; set; } = 0;
        public bool UseTls { get; set; } = false;



        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Host))    throw new InvalidOperationException("Configuration value 'SMTP->Connection->Host' is missing.");
            if (Port <= 0)                          throw new InvalidOperationException("Configuration value 'SMTP->Connection->Port' is missing or invalid.");
            // UseTls
        }
    }
}
