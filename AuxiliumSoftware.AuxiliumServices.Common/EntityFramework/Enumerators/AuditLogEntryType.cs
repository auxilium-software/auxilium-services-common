using System.Text.Json.Serialization;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AuditLogEntryType
{
    [JsonPropertyName("/service/api/start")]
    Service_API_Start,

    [JsonPropertyName("/system/bulletin/view")]
    System_Bulletin_View,
    [JsonPropertyName("/system/bulletin/dismissal")]
    System_Bulletin_Dismissal
}
