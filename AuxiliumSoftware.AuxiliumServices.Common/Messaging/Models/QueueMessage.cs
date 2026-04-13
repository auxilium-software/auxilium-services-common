using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AuxiliumSoftware.AuxiliumServices.Common.Messaging.Models
{
    public abstract class QueueMessage
    {
        public Guid MessageId { get; set; } = Guid.NewGuid();
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public string? CorrelationId { get; set; }

        [JsonIgnore]
        public abstract string RoutingKey { get; }
    }
}
