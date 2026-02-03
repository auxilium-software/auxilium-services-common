using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AuditLogActionTypeEnum
    {
        [JsonPropertyName("creation")]
        Creation,
        [JsonPropertyName("modification")]
        Modification,
        [JsonPropertyName("deletion")]
        Deletion,

        [JsonPropertyName("assignment")]
        Assignment,
        [JsonPropertyName("unassignment")]
        Unassignment,

        [JsonPropertyName("view")]
        View,

        [JsonPropertyName("send")]
        Send,

        [JsonPropertyName("upload")]
        Upload,
    }
}
