using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Policies.LoggingPolicy.EntityActions
{
    public class CreationsModificationsDeletionsSet
    {
        public required bool LogCreations { get; set; }
        public required bool LogModifications { get; set; }
        public required bool LogDeletions { get; set; }
    }
}
