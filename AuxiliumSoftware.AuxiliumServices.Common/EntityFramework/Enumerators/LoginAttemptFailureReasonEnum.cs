using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators
{
    public enum LoginAttemptFailureReasonEnum
    {
        [JsonPropertyName("invalidPassword")]
        InvalidPassword,

        [JsonPropertyName("userNotFound")]
        UserNotFound,

        [JsonPropertyName("accountLocked")]
        AccountLocked,

        [JsonPropertyName("ipBlocked")]
        IPBlocked,
    }
}
