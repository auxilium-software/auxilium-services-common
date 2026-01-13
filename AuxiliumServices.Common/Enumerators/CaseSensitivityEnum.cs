using System.Text.Json.Serialization;

namespace AuxiliumServices.Common.Enumerators
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
