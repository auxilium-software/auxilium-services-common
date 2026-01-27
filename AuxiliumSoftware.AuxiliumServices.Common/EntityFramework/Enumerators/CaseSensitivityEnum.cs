using System.Text.Json.Serialization;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CaseSensitivityEnum
    {
        [JsonPropertyName("public")]
        Public,

        [JsonPropertyName("internal")]
        Internal,

        [JsonPropertyName("confidential")]
        Confidential,

        [JsonPropertyName("restricted")]
        Restricted
    }
}
