using AuxiliumServices.Common.Configuration.Sections.FileSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumServices.Common.Configuration.Sections
{
    public class FileSystemConfigurationSection
    {
        public required RootStorageDirectoriesConfigurationSection RootStorageDirectories { get; set; }
    }
}
