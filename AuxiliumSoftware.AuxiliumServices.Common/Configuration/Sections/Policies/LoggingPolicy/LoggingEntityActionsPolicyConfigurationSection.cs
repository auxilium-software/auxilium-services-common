using AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Policies.LoggingPolicy.EntityActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Policies.LoggingPolicy
{
    public class LoggingEntityActionsPolicyConfigurationSection
    {
        public required CreationsModificationsDeletionsSet Cases { get; set; }
        public required CreationsModificationsDeletionsSet CaseAdditionalProperties { get; set; }
        public required AssignmentsUnassignmentsSet CaseWorkers { get; set; }
        public required AssignmentsUnassignmentsSet CaseClients { get; set; }
        public required SendsViewsSet CaseMessages { get; set; }
        public required UploadsViewsDeletionsSet CaseFiles { get; set; }
        public required CreationsModificationsDeletionsSet CaseTodos { get; set; }
        public required CreationsModificationsDeletionsSet Users { get; set; }
        public required CreationsModificationsDeletionsSet UsersAdditionalProperties { get; set; }
        public required UploadsViewsDeletionsSet UserFiles { get; set; }
    }
}
