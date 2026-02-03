using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Policies.LoggingPolicy.EntityActions
{
    public class AssignmentsUnassignmentsSet
    {
        public required bool LogAssignments { get; set; }
        public required bool LogUnassignments { get; set; }
    }
}
