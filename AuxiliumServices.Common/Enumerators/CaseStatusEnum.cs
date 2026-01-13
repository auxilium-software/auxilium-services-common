using System.Text.Json.Serialization;

namespace AuxiliumServices.Common.Enumerators
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CaseStatusEnum
    {
        [JsonPropertyName("staging")]
        Staging,

        [JsonPropertyName("open")]
        Open,

        [JsonPropertyName("closed")]
        Closed,

        [JsonPropertyName("archived")]
        Archived
    }
}
