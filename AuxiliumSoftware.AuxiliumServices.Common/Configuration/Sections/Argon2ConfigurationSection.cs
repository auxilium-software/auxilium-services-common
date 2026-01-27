using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections
{
    public class Argon2ConfigurationSection
    {
        public required int MemoryCost { get; set; }
        public required int TimeCost { get; set; }
        public required int Parallelism { get; set; }
        public required int HashLength { get; set; }
        public required int SaltLength { get; set; }
    }
}
