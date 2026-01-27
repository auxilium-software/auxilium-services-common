using System.Text.Json.Serialization;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators
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
