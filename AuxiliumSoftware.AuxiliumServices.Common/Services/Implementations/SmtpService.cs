using AuxiliumSoftware.AuxiliumServices.Common.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Net.Smtp;
using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework;
using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators;

namespace AuxiliumSoftware.AuxiliumServices.Common.Services.Implementations
{
    public class SmtpService : ISmtpService
    {
        private readonly ConfigurationStructure _configuration;
        private readonly SystemSettingsService _systemSettings;
        private readonly ILogger<SmtpService> _logger;

        public SmtpService(
            IConfiguration configuration,
            AuxiliumDbContext db,
            ISystemSettingsService systemSettingsService,
            ILogger<SmtpService> logger
        )
        {
            _configuration = new ConfigurationStructure();
            configuration.Bind(_configuration);
            _logger = logger;
        }

        public async Task SendAsync(string toAddress, string subject, string htmlBody)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(
                _configuration.SMTP.SenderName,
                _configuration.SMTP.SenderAddress
            ));
            message.To.Add(MailboxAddress.Parse(toAddress));
            message.Subject = subject;
            message.Body = new TextPart("html") { Text = htmlBody };

            using var client = new SmtpClient();

            try
            {
                await client.ConnectAsync(
                    _configuration.SMTP.Host,
                    _configuration.SMTP.Port,
                    MailKit.Security.SecureSocketOptions.None
                );

                if (_configuration.SMTP.Authentication.UseAuthentication)
                {
                    await client.AuthenticateAsync(
                        _configuration.SMTP.Authentication.Username,
                        _configuration.SMTP.Authentication.Password
                    );
                }

                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                _logger.LogInformation("Email sent to {ToAddress}: {Subject}", toAddress, subject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email to {ToAddress}: {Subject}", toAddress, subject);
                throw;
            }
        }
    }
}
