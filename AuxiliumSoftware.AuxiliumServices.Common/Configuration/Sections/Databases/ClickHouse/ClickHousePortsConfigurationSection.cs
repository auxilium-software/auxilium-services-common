using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Databases.ClickHouse
{
    public class ClickHousePortsConfigurationSection
    {
        public required int HTTP { get; set; }
        public required int TCP { get; set; }
    }
}
