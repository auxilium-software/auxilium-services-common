using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumServices.Common.Configuration.Sections.FileSystem
{
    public class RootStorageDirectoriesConfigurationSection
    {
        public required string AuxLFS { get; set; }
        public required string SecondaryLogs { get; set; }
    }
}
