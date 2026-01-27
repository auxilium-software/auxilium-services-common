using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SystemBulletinMessageTargetAudienceEnum
    {
        [JsonPropertyName("everyone")]
        Everyone,

        [JsonPropertyName("logged_in_users_only")]
        LoggedInUsersOnly,

        [JsonPropertyName("public_only")]
        PublicOnly,

        [JsonPropertyName("single_user_only")]
        SingleUserOnly,
    }
}
