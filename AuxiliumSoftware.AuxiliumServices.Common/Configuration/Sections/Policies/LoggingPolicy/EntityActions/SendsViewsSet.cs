using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Policies.LoggingPolicy.EntityActions
{
    public class SendsViewsSet
    {
        public required bool LogSends { get; set; }
        public required bool LogViews { get; set; }
    }
}
