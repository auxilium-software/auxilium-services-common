using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.FileSystem
{
    public class RootStorageDirectoriesConfigurationSection
    {
        public string AuxLFS { get; set; } = null!;
        


        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(AuxLFS))  throw new InvalidOperationException("Configuration value 'RootStorageDirectories->AuxLFS' is missing.");
        }
    }
}
