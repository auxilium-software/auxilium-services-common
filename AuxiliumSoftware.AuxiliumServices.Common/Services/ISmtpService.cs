using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Services
{
    public interface ISmtpService
    {
        Task SendAsync(string toAddress, string subject, string htmlBody);
    }
}
