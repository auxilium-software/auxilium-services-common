using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels
{
    public class AuditLogEntryEntityModel
    {
        public required Guid Id { get; set; }
        public required DateTime CreatedAt { get; set; }
        public Guid? CreatedBy { get; set; }



        public required AuditLogEntryType EventType { get; set; }
        public required string ClientIPAddress { get; set; }
        public required Dictionary<AuditLogEntryMetadataKey, object> Metadata { get; set; }



        public UserEntityModel? CreatedByUser { get; set; }
    }
}
