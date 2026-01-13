using System.Text.Json.Serialization;

namespace AuxiliumServices.Common.Enumerators
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TodoPriorityEnum
    {
        [JsonPropertyName("low")]
        Low,

        [JsonPropertyName("medium")]
        Medium,

        [JsonPropertyName("high")]
        High,

        [JsonPropertyName("urgent")]
        Urgent,
    }
}
