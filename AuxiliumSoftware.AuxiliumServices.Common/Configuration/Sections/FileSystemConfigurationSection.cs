using AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.FileSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections
{
    public class FileSystemConfigurationSection
    {
        public RootStorageDirectoriesConfigurationSection RootStorageDirectories { get; set; } = null!;



        public void Validate()
        {
            RootStorageDirectories.Validate();
        }
    }
}
