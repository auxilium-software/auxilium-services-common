using AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.FileSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections
{
    public class FileSystemConfigurationSection
    {
        public required RootStorageDirectoriesConfigurationSection RootStorageDirectories { get; set; }
    }
}
