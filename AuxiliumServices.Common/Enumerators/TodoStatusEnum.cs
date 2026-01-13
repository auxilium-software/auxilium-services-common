using System.Text.Json.Serialization;

namespace AuxiliumServices.Common.Enumerators
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TodoStatusEnum
    {
        [JsonPropertyName("needs_action")]
        NeedsAction,

        [JsonPropertyName("in_progress")]
        InProgress,

        [JsonPropertyName("completed")]
        Completed,

        [JsonPropertyName("cancelled")]
        Cancelled,
    }
}
