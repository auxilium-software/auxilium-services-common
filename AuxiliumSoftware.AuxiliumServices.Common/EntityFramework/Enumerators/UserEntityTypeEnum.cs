using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserEntityTypeEnum
    {
        [JsonPropertyName("/user")]
        User,

        [JsonPropertyName("/user/additional_property")]
        User_AdditionalProperty,

        [JsonPropertyName("/user/file")]
        User_File,
    }
}
