using AuxiliumSoftware.AuxiliumServices.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators
{
    public enum SystemSettingKeyEnum
    {
        // ####################################################################################################
        // Policies -> Web Application Firewall
        // ####################################################################################################
        // Web Application Firewall
        [JsonPropertyName("policies.webApplicationFirewall.enabled")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_WebApplicationFirewall_Enabled,

        // Web Application Firewall - User
        [JsonPropertyName("policies.webApplicationFirewall.user.maximumFailedLoginsPerUser")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Int)]
        [SystemSettingDefaultValueAttribute(5)]
        Policies_WebApplicationFirewall_User_MaximumFailedLoginsPerUser,

        [JsonPropertyName("policies.webApplicationFirewall.user.userLockoutWindowInMinutes")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Int)]
        [SystemSettingDefaultValueAttribute()]
        Policies_WebApplicationFirewall_User_UserLockoutWindowInMinutes,

        [JsonPropertyName("policies.webApplicationFirewall.user.userLockoutDurationInMinutes")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Int)]
        [SystemSettingDefaultValueAttribute()]
        Policies_WebApplicationFirewall_User_UserLockoutDurationInMinutes,

        // Web Application Firewall - IP
        [JsonPropertyName("policies.webApplicationFirewall.ip.maximumFailedLoginsPerIp")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Int)]
        [SystemSettingDefaultValueAttribute()]
        Policies_WebApplicationFirewall_Ip_MaximumFailedLoginsPerIp,

        [JsonPropertyName("policies.webApplicationFirewall.ip.ipBlockWindowInMinutes")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Int)]
        [SystemSettingDefaultValueAttribute()]
        Policies_WebApplicationFirewall_Ip_IpBlockWindowInMinutes,

        [JsonPropertyName("policies.webApplicationFirewall.ip.ipTemporaryBlockDurationInMinutes")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Int)]
        [SystemSettingDefaultValueAttribute()]
        Policies_WebApplicationFirewall_Ip_IpTemporaryBlockDurationInMinutes,

        [JsonPropertyName("policies.webApplicationFirewall.ip.temporaryBlocksBeforePermanentBan")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Int)]
        [SystemSettingDefaultValueAttribute()]
        Policies_WebApplicationFirewall_Ip_TemporaryBlocksBeforePermanentBan,

        [JsonPropertyName("policies.webApplicationFirewall.ip.permanentBanWindowHours")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Int)]
        [SystemSettingDefaultValueAttribute()]
        Policies_WebApplicationFirewall_Ip_PermanentBanWindowHours,

        // Web Application Firewall - Rate Limiting
        [JsonPropertyName("policies.webApplicationFirewall.rateLimiting.enabled")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_WebApplicationFirewall_RateLimiting_Enabled,

        [JsonPropertyName("policies.webApplicationFirewall.rateLimiting.enabled.rateLimitBasedUponIpAddress")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Int)]
        [SystemSettingDefaultValueAttribute()]
        Policies_WebApplicationFirewall_RateLimiting_RateLimitBasedUponIpAddress,

        [JsonPropertyName("policies.webApplicationFirewall.rateLimiting.enabled.rateLimitBasedUponUserAccount")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Int)]
        [SystemSettingDefaultValueAttribute()]
        Policies_WebApplicationFirewall_RateLimiting_RateLimitBasedUponUserAccount,

        [JsonPropertyName("policies.webApplicationFirewall.rateLimiting.maximumLoginRequestsPerMinute")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Int)]
        [SystemSettingDefaultValueAttribute()]
        Policies_WebApplicationFirewall_RateLimiting_MaximumLoginRequestsPerMinute,

        [JsonPropertyName("policies.webApplicationFirewall.rateLimiting.failureDelayBaseMilliseconds")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Int)]
        [SystemSettingDefaultValueAttribute()]
        Policies_WebApplicationFirewall_RateLimiting_FailureDelayBaseMilliseconds,

        [JsonPropertyName("policies.webApplicationFirewall.rateLimiting.failureDelayMaximumMilliseconds")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Int)]
        [SystemSettingDefaultValueAttribute()]
        Policies_WebApplicationFirewall_RateLimiting_FailureDelayMaximumMilliseconds,

        // Web Application Firewall - Whitelisting
        [JsonPropertyName("policies.webApplicationFirewall.whitelisting.whitelistedIps")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.StringArray)]
        Policies_WebApplicationFirewall_Whitelisting_WhitelistedIps,

        // Web Application Firewall - Distributed Attack Detection
        // [JsonPropertyName("policies.webApplicationFirewall.distributedAttackDetection.ipThreshold")]
        // Policies_WebApplicationFirewall_DistributedAttackDetection_IpThreshold,

        [JsonPropertyName("policies.webApplicationFirewall.distributedAttackDetection.windowInMinutes")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Int)]
        [SystemSettingDefaultValueAttribute()]
        Policies_WebApplicationFirewall_DistributedAttackDetection_WindowInMinutes,

        // ####################################################################################################
        // Policies -> Password
        // ####################################################################################################
        [JsonPropertyName("policies.password.minimumLength")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Int)]
        [SystemSettingDefaultValueAttribute(8)]
        Policies_Password_MinimumLength,

        [JsonPropertyName("policies.password.requireUppercase")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Password_RequireUppercase,

        [JsonPropertyName("policies.password.requireLowercase")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Password_RequireLowercase,

        [JsonPropertyName("policies.password.requireNumeric")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Password_RequireNumeric,

        [JsonPropertyName("policies.password.requireSpecialCharacter")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Password_RequireSpecialCharacter,

        [JsonPropertyName("policies.password.maximumAgeInDays")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Int)]
        [SystemSettingDefaultValueAttribute(365)]
        Policies_Password_MaximumAgeInDays,

        [JsonPropertyName("policies.password.allowCommonPasswords")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(false)]
        Policies_Password_AllowCommonPasswords,

        [JsonPropertyName("policies.password.preventPasswordReuse")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Password_PreventPasswordReuse,

        // ####################################################################################################
        // Policies -> TOTP
        // ####################################################################################################
        [JsonPropertyName("policies.totp.requireForAdministrators")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Totp_RequireForAdministrators,

        [JsonPropertyName("policies.totp.requireForAllNonAdministrators")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(false)]
        Policies_Totp_RequireForAllNonAdministrators,

        [JsonPropertyName("policies.totp.totpIssuer")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.String)]
        [SystemSettingDefaultValueAttribute("Auxilium")]
        Policies_Totp_TotpIssuer,

        [JsonPropertyName("policies.totp.numberOfRecoveryCodesToGenerate")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Int)]
        [SystemSettingDefaultValueAttribute(8)]
        Policies_Totp_NumberOfRecoveryCodesToGenerate,

        // ####################################################################################################
        // Policies -> Account Lockout
        // ####################################################################################################
        [JsonPropertyName("policies.accountLockout.maximumFailedLoginAttempts")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Int)]
        [SystemSettingDefaultValueAttribute()]
        Policies_AccountLockout_MaximumFailedLoginAttempts,

        [JsonPropertyName("policies.accountLockout.lockoutDurationInMinutes")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Int)]
        [SystemSettingDefaultValueAttribute()]
        Policies_AccountLockout_LockoutDurationInMinutes,

        [JsonPropertyName("policies.accountLockout.resetFailedAttemptsAfterInMinutes")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Int)]
        [SystemSettingDefaultValueAttribute()]
        Policies_AccountLockout_ResetFailedAttemptsAfterInMinutes,

        [JsonPropertyName("policies.accountLockout.notifyUserUponLockout")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Int)]
        [SystemSettingDefaultValueAttribute()]
        Policies_AccountLockout_NotifyUserUponLockout,

        // ####################################################################################################
        // Policies -> Logging
        // ####################################################################################################
        // Logging - Security
        [JsonPropertyName("policies.logging.security.logSuccessfulLogins")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_Security_LogSuccessfulLogins,

        [JsonPropertyName("policies.logging.security.logIncorrectPasswordLoginAttempts")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_Security_LogIncorrectPasswordLoginAttempts,

        [JsonPropertyName("policies.logging.security.logIncorrectEmailAddressLoginAttempts")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_Security_LogIncorrectEmailAddressLoginAttempts,

        [JsonPropertyName("policies.logging.security.logPasswordChanges")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_Security_LogPasswordChanges,

        // Logging - Entity Actions - Cases
        [JsonPropertyName("policies.logging.entityActions.cases.logCreations")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_Cases_LogCreations,

        [JsonPropertyName("policies.logging.entityActions.cases.logModifications")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_Cases_LogModifications,

        [JsonPropertyName("policies.logging.entityActions.cases.logDeletions")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_Cases_LogDeletions,

        // Logging - Entity Actions - Case Additional Properties
        [JsonPropertyName("policies.logging.entityActions.caseAdditionalProperties.logCreations")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_CaseAdditionalProperties_LogCreations,

        [JsonPropertyName("policies.logging.entityActions.caseAdditionalProperties.logModifications")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_CaseAdditionalProperties_LogModifications,

        [JsonPropertyName("policies.logging.entityActions.caseAdditionalProperties.logDeletions")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_CaseAdditionalProperties_LogDeletions,

        // Logging - Entity Actions - Case Workers
        [JsonPropertyName("policies.logging.entityActions.caseWorkers.logAssignments")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_CaseWorkers_LogAssignments,

        [JsonPropertyName("policies.logging.entityActions.caseWorkers.logUnAssignments")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_CaseWorkers_LogUnAssignments,

        // Logging - Entity Actions - Case Clients
        [JsonPropertyName("policies.logging.entityActions.caseClients.logAssignments")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_CaseClients_LogAssignments,

        [JsonPropertyName("policies.logging.entityActions.caseClients.logUnAssignments")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_CaseClients_LogUnAssignments,

        // Logging - Entity Actions - Case Messages
        [JsonPropertyName("policies.logging.entityActions.caseMessages.logSends")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_CaseMessages_LogSends,

        [JsonPropertyName("policies.logging.entityActions.caseMessages.logViews")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_CaseMessages_LogViews,

        // Logging - Entity Actions - Case Files
        [JsonPropertyName("policies.logging.entityActions.caseFiles.logUploads")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_CaseFiles_LogUploads,

        [JsonPropertyName("policies.logging.entityActions.caseFiles.logViews")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_CaseFiles_LogViews,

        [JsonPropertyName("policies.logging.entityActions.caseFiles.logDeletions")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_CaseFiles_LogDeletions,

        // Logging - Entity Actions - Case Todos
        [JsonPropertyName("policies.logging.entityActions.caseTodos.logCreations")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_CaseTodos_LogCreations,

        [JsonPropertyName("policies.logging.entityActions.caseTodos.logModifications")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_CaseTodos_LogModifications,

        [JsonPropertyName("policies.logging.entityActions.caseTodos.logDeletions")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_CaseTodos_LogDeletions,

        // Logging - Entity Actions - Users
        [JsonPropertyName("policies.logging.entityActions.users.logCreations")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_Users_LogCreations,

        [JsonPropertyName("policies.logging.entityActions.users.logModifications")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_Users_LogModifications,

        [JsonPropertyName("policies.logging.entityActions.users.logDeletions")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_Users_LogDeletions,

        // Logging - Entity Actions - User Additional Properties
        [JsonPropertyName("policies.logging.entityActions.userAdditionalProperties.logCreations")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_UserAdditionalProperties_LogCreations,

        [JsonPropertyName("policies.logging.entityActions.userAdditionalProperties.logModifications")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_UserAdditionalProperties_LogModifications,

        [JsonPropertyName("policies.logging.entityActions.userAdditionalProperties.logDeletions")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_UserAdditionalProperties_LogDeletions,

        // Logging - Entity Actions - User Files
        [JsonPropertyName("policies.logging.entityActions.userFiles.logUploads")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_UserFiles_LogUploads,

        [JsonPropertyName("policies.logging.entityActions.userFiles.logViews")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_UserFiles_LogViews,

        [JsonPropertyName("policies.logging.entityActions.userFiles.logDeletions")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.Bool)]
        [SystemSettingDefaultValueAttribute(true)]
        Policies_Logging_EntityActions_UserFiles_LogDeletions,










        // ####################################################################################################
        // Instance
        // ####################################################################################################
        [JsonPropertyName("instance.fqdn")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.String)]
        Instance_Fqdn,

        [JsonPropertyName("instance.branding.logoRelativePath")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.String)]
        Instance_Branding_LogoRelativePath,

        [JsonPropertyName("instance.branding.logoContrastRelativePath")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.String)]
        Instance_Branding_LogoContrastRelativePath,

        [JsonPropertyName("instance.branding.name")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.String)]
        Instance_Branding_Name,

        // contacts
        [JsonPropertyName("instance.contacts.firstPointOfContact.emailAddress")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.String)]
        Instance_Contacts_FirstPointOfContact_EmailAddress,

        [JsonPropertyName("instance.contacts.firstPointOfContact.phone.number")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.String)]
        Instance_Contacts_FirstPointOfContact_Phone_Number,

        [JsonPropertyName("instance.contacts.firstPointOfContact.phone.openingHours")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.String)]
        Instance_Contacts_FirstPointOfContact_Phone_OpeningHours,

        [JsonPropertyName("instance.contacts.firstPointOfContact.text.number")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.String)]
        Instance_Contacts_FirstPointOfContact_Text_Number,

        [JsonPropertyName("instance.contacts.firstPointOfContact.text.openingHours")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.String)]
        Instance_Contacts_FirstPointOfContact_Text_OpeningHours,

        [JsonPropertyName("instance.contacts.maintainer.name")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.String)]
        Instance_Contacts_Maintainer_Name,

        [JsonPropertyName("instance.contacts.maintainer.emailAddress")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.String)]
        Instance_Contacts_Maintainer_EmailAddress,

        [JsonPropertyName("instance.contacts.operator.name")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.String)]
        Instance_Contacts_Operator_Name,

        [JsonPropertyName("instance.contacts.operator.emailAddress")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.String)]
        Instance_Contacts_Operator_EmailAddress,

        [JsonPropertyName("instance.contacts.generalEnquiries.name")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.String)]
        Instance_Contacts_GeneralEnquiries_Name,

        [JsonPropertyName("instance.contacts.generalEnquiries.emailAddress")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.String)]
        Instance_Contacts_GeneralEnquiries_EmailAddress,

        // defaults
        [JsonPropertyName("instance.defaults.timeZone")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.String)]
        Instance_Defaults_TimeZone,

        [JsonPropertyName("instance.defaults.language")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.String)]
        Instance_Defaults_Language,

        // navigation
        [JsonPropertyName("instance.navigation.aboutPageRelativePath")]
        [SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum.String)]
        Instance_Navigation_AboutPageRelativePath,
    }
}
