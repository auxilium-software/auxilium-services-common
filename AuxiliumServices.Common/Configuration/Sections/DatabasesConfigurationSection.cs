using AuxiliumServices.Common.Configuration.Sections.Databases;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumServices.Common.Configuration.Sections
{
    public class DatabasesConfigurationSection
    {
        public MariaDBConfigurationSection MariaDB { get; set; }
        public RabbitMQConfigurationSection RabbitMQ { get; set; }
        public ClickHouseConfigurationSection ClickHouse { get; set; }
    }
}
