using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections
{
    public class Argon2ConfigurationSection
    {
        public int MemoryCost { get; set; } = 0;
        public int TimeCost { get; set; } = 0;
        public int Parallelism { get; set; } = 0;
        public int HashLength { get; set; } = 0;
        public int SaltLength { get; set; } = 0;
        


        public void Validate()
        {
            if (MemoryCost <= 0)    throw new InvalidOperationException("Configuration value 'Argon2->MemoryCost' is missing or invalid.");
            if (TimeCost <= 0)      throw new InvalidOperationException("Configuration value 'Argon2->TimeCost' is missing or invalid.");
            if (Parallelism <= 0)   throw new InvalidOperationException("Configuration value 'Argon2->Parallelism' is missing or invalid.");
            if (HashLength <= 0)    throw new InvalidOperationException("Configuration value 'Argon2->HashLength' is missing or invalid.");
            if (SaltLength <= 0)    throw new InvalidOperationException("Configuration value 'Argon2->SaltLength' is missing or invalid.");
        }
    }
}
