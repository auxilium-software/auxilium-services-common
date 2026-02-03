using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Policies.LoggingPolicy.EntityActions
{
    public class UploadsViewsDeletionsSet
    {
        public required bool LogUploads { get; set; }
        public required bool LogViews { get; set; }
        public required bool LogDeletions { get; set; }
    }
}
