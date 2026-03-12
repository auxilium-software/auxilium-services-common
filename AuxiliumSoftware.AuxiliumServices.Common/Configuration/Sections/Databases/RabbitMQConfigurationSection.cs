using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Databases
{
    public class RabbitMQConfigurationSection
    {
        public string Host { get; set; } = null!;
        public int Port { get; set; } = 0;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string VirtualHost { get; set; } = null!;
        public int HeartbeatInSeconds { get; set; } = 0;
        public int BlockedConnectionTimeoutInSeconds { get; set; } = 0;
        public string ExchangeName { get; set; } = null!;
        public Dictionary<string, string> Queues { get; set; } = null!;



        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Host))            throw new InvalidOperationException("Configuration value 'Databases->MariaDB->Host' is missing.");
            if (Port <= 0)                                  throw new InvalidOperationException("Configuration value 'Databases->MariaDB->Port' is missing or invalid.");
            if (string.IsNullOrWhiteSpace(Username))        throw new InvalidOperationException("Configuration value 'Databases->MariaDB->Username' is missing.");
            if (string.IsNullOrWhiteSpace(Password))        throw new InvalidOperationException("Configuration value 'Databases->MariaDB->Password' is missing.");
            if (string.IsNullOrWhiteSpace(VirtualHost))     throw new InvalidOperationException("Configuration value 'Databases->MariaDB->VirtualHost' is missing.");
            if (HeartbeatInSeconds <= 0)                    throw new InvalidOperationException("Configuration value 'Databases->MariaDB->HeartbeatInSeconds' is missing or invalid.");
            if (BlockedConnectionTimeoutInSeconds <= 0)     throw new InvalidOperationException("Configuration value 'Databases->MariaDB->BlockedConnectionTimeoutInSeconds' is missing or invalid.");
            if (string.IsNullOrWhiteSpace(ExchangeName))    throw new InvalidOperationException("Configuration value 'Databases->MariaDB->ExchangeName' is missing.");
            if (Queues is null || Queues.Count == 0)        throw new InvalidOperationException("Configuration value 'Databases->MariaDB->Queues' is missing.");
        }
    }
}
