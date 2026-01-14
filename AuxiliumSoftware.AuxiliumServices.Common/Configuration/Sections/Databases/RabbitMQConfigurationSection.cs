using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Databases
{
    public class RabbitMQConfigurationSection
    {
        public required string Host { get; set; }
        public required int Port { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string VirtualHost { get; set; }
        public required int HeartbeatInSeconds { get; set; }
        public required int BlockedConnectionTimeoutInSeconds { get; set; }
        public required string ExchangeName { get; set; }
        public required Dictionary<string, string> Queues { get; set; }
    }
}
