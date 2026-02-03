using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AuditLogActionTypeEnum
    {
        [JsonPropertyName("created")]
        Created,

        [JsonPropertyName("modified")]
        Modified,

        [JsonPropertyName("deleted")]
        Deleted
    }
}
