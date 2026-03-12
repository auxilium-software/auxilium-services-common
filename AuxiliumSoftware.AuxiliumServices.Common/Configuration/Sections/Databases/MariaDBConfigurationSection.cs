using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Databases
{
    public class MariaDBConfigurationSection
    {
        public string Host { get; set; } = null!;
        public int Port { get; set; } = 0;
        public string Database { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        


        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Host))        throw new InvalidOperationException("Configuration value 'Databases->MariaDB->Host' is missing.");
            if (Port <= 0)                              throw new InvalidOperationException("Configuration value 'Databases->MariaDB->Port' is missing or invalid.");
            if (string.IsNullOrWhiteSpace(Database))    throw new InvalidOperationException("Configuration value 'Databases->MariaDB->Database' is missing.");
            if (string.IsNullOrWhiteSpace(Username))    throw new InvalidOperationException("Configuration value 'Databases->MariaDB->Username' is missing.");
            if (string.IsNullOrWhiteSpace(Password))    throw new InvalidOperationException("Configuration value 'Databases->MariaDB->Password' is missing.");
        }
    }
}
