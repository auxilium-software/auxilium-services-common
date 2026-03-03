using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AuxiliumSoftware.AuxiliumServices.Common.Enumerators
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CasbinPolicyActionTypeEnum
    {
        [JsonPropertyName("PolicyAction.Read")]
        Read,

        [JsonPropertyName("PolicyAction.Write")]
        Write,
    }
}
