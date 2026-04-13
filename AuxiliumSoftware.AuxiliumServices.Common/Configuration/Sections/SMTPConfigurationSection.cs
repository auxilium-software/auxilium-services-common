using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections
{
    public class SMTPConfigurationSection
    {
        public string Host { get; set; } = null!;
        public int Port { get; set; } = 0;
        


        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Host))    throw new InvalidOperationException("Configuration value 'SMTP->Host' is missing.");
            if (Port <= 0)                          throw new InvalidOperationException("Configuration value 'SMTP->Port' is missing or invalid.");
        }
    }
}
