using System.Text.Json.Serialization;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AuditLogEntryType
{
    [JsonPropertyName("/service/api/start")]
    Service_API_Start
}
