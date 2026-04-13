using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.SMTP
{
    public class SMTPAuthenticationConfigurationSection
    {
        public bool UseAuthentication { get; set; } = false;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;



        public void Validate()
        {
            // UseAuthentication
            if (string.IsNullOrWhiteSpace(Username))    throw new InvalidOperationException("Configuration value 'SMTP->Authentication->Username' is missing.");
            if (string.IsNullOrWhiteSpace(Password))    throw new InvalidOperationException("Configuration value 'SMTP->Authentication->Password' is missing.");
        }
    }
}
