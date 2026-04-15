using AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.SMTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections
{
    public class SMTPConfigurationSection
    {
        public bool SendEmailsFromPortal { get; set; } = false;
        public SMTPConnectionConfigurationSection Connection { get; set; } = null!;
        public SMTPAuthenticationConfigurationSection Authentication { get; set; } = null!;
        public SMTPFromConfigurationSection From { get; set; } = null!;



        public void Validate()
        {
            // SendEmailsFromPortal
            Connection.Validate();
            Authentication.Validate();
            From.Validate();
        }
    }
}
