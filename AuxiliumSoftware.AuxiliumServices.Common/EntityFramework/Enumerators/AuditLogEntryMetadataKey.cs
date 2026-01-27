using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AuditLogEntryMetadataKey
    {
        [JsonPropertyName("objectType")]
        ObjectType,

        [JsonPropertyName("objectId")]
        ObjectId,

        [JsonPropertyName("reason")]
        Reason,

        [JsonPropertyName("attemptedEmailAddress")]
        AttemptedUsername
    }
}
