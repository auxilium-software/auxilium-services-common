using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SystemBulletinMessageSeverityEnum
    {
        [JsonPropertyName("informational")]
        Informational,

        [JsonPropertyName("warning")]
        Warning,

        [JsonPropertyName("critical")]
        Critical,
    }
}
