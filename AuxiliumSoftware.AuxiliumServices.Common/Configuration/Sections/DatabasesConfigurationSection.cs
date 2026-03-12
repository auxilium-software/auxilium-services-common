using AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Databases;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections
{
    public class DatabasesConfigurationSection
    {
        public MariaDBConfigurationSection MariaDB { get; set; } = null!;
        public RabbitMQConfigurationSection RabbitMQ { get; set; } = null!;



        public void Validate()
        {
            if (MariaDB is null)    throw new InvalidOperationException("Configuration section 'Databases->MariaDB' is missing.");
            if (RabbitMQ is null)   throw new InvalidOperationException("Configuration section 'Databases->MariaDB' is missing.");

            MariaDB.Validate();
            RabbitMQ.Validate();
        }
    }
}
