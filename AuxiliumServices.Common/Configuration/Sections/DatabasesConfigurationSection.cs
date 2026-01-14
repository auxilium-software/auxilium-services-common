using AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Databases;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections
{
    public class DatabasesConfigurationSection
    {
        public required MariaDBConfigurationSection MariaDB { get; set; }
        public required RabbitMQConfigurationSection RabbitMQ { get; set; }
        public required ClickHouseConfigurationSection ClickHouse { get; set; }
    }
}
