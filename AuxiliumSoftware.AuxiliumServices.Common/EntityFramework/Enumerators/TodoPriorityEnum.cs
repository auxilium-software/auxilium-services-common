using System.Text.Json.Serialization;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators
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
