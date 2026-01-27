using System.Text.Json.Serialization;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators
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
