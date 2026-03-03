using System.Text.Json.Serialization;

namespace AuxiliumSoftware.AuxiliumServices.Common.Enumerators
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DatabaseObjectTypeEnum
    {
        [JsonPropertyName("System.SettingEntry")]
        System_SettingEntry,

        [JsonPropertyName("System.Waf.IpWhitelistEntry")]
        System_Waf_IpWhitelistEntry,
        [JsonPropertyName("System.Waf.IpBlacklistEntry")]
        System_Waf_IpBlacklistEntry,
        [JsonPropertyName("System.Waf.UserWhitelistEntry")]
        System_Waf_UserWhitelistEntry,
        [JsonPropertyName("System.Waf.UserBlacklistEntry")]
        System_Waf_UserBlacklistEntry,

        [JsonPropertyName("System.BulletinEntry")]
        System_BulletinEntry,



        [JsonPropertyName("User")]
        User,
        [JsonPropertyName("User.AdditionalProperty")]
        User_AdditionalProperty,
        [JsonPropertyName("User.File")]
        User_File,
        [JsonPropertyName("User.RefreshToken")]
        User_RefreshToken,
        [JsonPropertyName("User.TotpRecoveryCode")]
        User_TotpRecoveryCode,
        [JsonPropertyName("User.WemwbsAssessment")]
        User_WemwbsAssessment,



        [JsonPropertyName("Case")]
        Case,
        [JsonPropertyName("CaseAdditionalProperty")]
        Case_AdditionalProperty,
        [JsonPropertyName("CaseWorker")]
        Case_Worker,
        [JsonPropertyName("CaseClient")]
        Case_Client,
        [JsonPropertyName("CaseMessage")]
        Case_Message,
        [JsonPropertyName("CaseFile")]
        Case_File,
        [JsonPropertyName("CaseTodo")]
        Case_Todo,



        [JsonPropertyName("Log.CaseMessageReadByEventEntry")]
        Log_CaseMessageReadByEventEntry,
        [JsonPropertyName("Log.CaseModificationEventEntry")]
        Log_CaseModificationEventEntry,
        [JsonPropertyName("Log.LoginAttemptEventEntry")]
        Log_LoginAttemptEventEntry,
        [JsonPropertyName("Log.SystemBulletinEntryDismissalEventEntry")]
        Log_SystemBulletinEntryDismissalEventEntry,
        [JsonPropertyName("Log.SystemBulletinEntryViewEventEntry")]
        Log_SystemBulletinEntryViewEventEntry,
        [JsonPropertyName("Log.UserModificationEventEntry")]
        Log_UserModificationEventEntry,
    }
}
