using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators
{
    public enum SystemSettingKeyEnum
    {
        // ####################################################################################################
        // Database Configuration
        // ####################################################################################################
        [JsonPropertyName("databases.rabbitmq.hostname")]
        Databases_RabbitMq_Hostname,

        [JsonPropertyName("databases.rabbitmq.port")]
        Databases_RabbitMq_Port,

        [JsonPropertyName("databases.rabbitmq.username")]
        Databases_RabbitMq_Username,

        [JsonPropertyName("databases.rabbitmq.password")]
        Databases_RabbitMq_Password,

        [JsonPropertyName("databases.rabbitmq.virtualHost")]
        Databases_RabbitMq_VirtualHost,

        [JsonPropertyName("databases.rabbitmq.heartbeatIntervalInSeconds")]
        Databases_RabbitMq_HeartbeatIntervalInSeconds,

        [JsonPropertyName("databases.rabbitmq.blockedConnectionTimeoutInSeconds")]
        Databases_RabbitMq_BlockedConnectionTimeoutInSeconds,

        [JsonPropertyName("databases.rabbitmq.exchangeName")]
        Databases_RabbitMq_ExchangeName,

        [JsonPropertyName("databases.rabbitmq.queues.notifications")]
        Databases_RabbitMq_Queues_Notifications,

        // ####################################################################################################
        // ReCAPTCHA Configuration
        // ####################################################################################################
        [JsonPropertyName("recaptcha.siteKey")]
        Recaptcha_SiteKey,

        [JsonPropertyName("recaptcha.secretKey")]
        Recaptcha_SecretKey,

        [JsonPropertyName("recaptcha.scoreThreshold")]
        Recaptcha_ScoreThreshold,

        // ####################################################################################################
        // JWT Configuration
        // ####################################################################################################
        [JsonPropertyName("jwt.secretKey")]
        Jwt_SecretKey,

        [JsonPropertyName("jwt.algorithm")]
        Jwt_Algorithm,

        [JsonPropertyName("jwt.mfaTokenExpirationInSeconds")]
        Jwt_MfaTokenExpirationInSeconds,

        [JsonPropertyName("jwt.accessTokenExpirationInMinutes")]
        Jwt_AccessTokenExpirationInMinutes,

        [JsonPropertyName("jwt.refreshTokenExpirationInDays")]
        Jwt_RefreshTokenExpirationInDays,

        [JsonPropertyName("jwt.validIssuer")]
        Jwt_ValidIssuer,

        [JsonPropertyName("jwt.validAudiencePrefix")]
        Jwt_ValidAudiencePrefix,

        // ####################################################################################################
        // API Configuration
        // ####################################################################################################
        [JsonPropertyName("api.protocol")]
        Api_Protocol,

        [JsonPropertyName("api.availableFrom")]
        Api_AvailableFrom,

        [JsonPropertyName("api.port")]
        Api_Port,

        [JsonPropertyName("api.availableAt")]
        Api_AvailableAt,

        [JsonPropertyName("api.cors.allowedOrigins")]
        Api_Cors_AllowedOrigins,

        [JsonPropertyName("api.cors.allowedHosts")]
        Api_Cors_AllowedHosts,

        [JsonPropertyName("api.webApplicationFirewall.enabled")]
        Api_WebApplicationFirewall_Enabled,

        // ####################################################################################################
        // File System Configuration
        // ####################################################################################################
        [JsonPropertyName("fileSystem.rootStorageDirectories.auxLfs")]
        FileSystem_RootStorageDirectories_AuxLfs,

        // ####################################################################################################
        // Policies -> Web Application Firewall
        // ####################################################################################################
        // Web Application Firewall - User
        [JsonPropertyName("policies.webApplicationFirewall.user.maximumFailedLoginsPerUser")]
        Policies_WebApplicationFirewall_User_MaximumFailedLoginsPerUser,

        [JsonPropertyName("policies.webApplicationFirewall.user.userLockoutWindowInMinutes")]
        Policies_WebApplicationFirewall_User_UserLockoutWindowInMinutes,

        [JsonPropertyName("policies.webApplicationFirewall.user.userLockoutDurationInMinutes")]
        Policies_WebApplicationFirewall_User_UserLockoutDurationInMinutes,

        // Web Application Firewall - IP
        [JsonPropertyName("policies.webApplicationFirewall.ip.maximumFailedLoginsPerIp")]
        Policies_WebApplicationFirewall_Ip_MaximumFailedLoginsPerIp,

        [JsonPropertyName("policies.webApplicationFirewall.ip.ipBlockWindowInMinutes")]
        Policies_WebApplicationFirewall_Ip_IpBlockWindowInMinutes,

        [JsonPropertyName("policies.webApplicationFirewall.ip.ipTemporaryBlockDurationInMinutes")]
        Policies_WebApplicationFirewall_Ip_IpTemporaryBlockDurationInMinutes,

        [JsonPropertyName("policies.webApplicationFirewall.ip.temporaryBlocksBeforePermanentBan")]
        Policies_WebApplicationFirewall_Ip_TemporaryBlocksBeforePermanentBan,

        [JsonPropertyName("policies.webApplicationFirewall.ip.permanentBanWindowHours")]
        Policies_WebApplicationFirewall_Ip_PermanentBanWindowHours,

        // Web Application Firewall - Rate Limiting
        [JsonPropertyName("policies.webApplicationFirewall.rateLimiting.maximumLoginRequestsPerMinute")]
        Policies_WebApplicationFirewall_RateLimiting_MaximumLoginRequestsPerMinute,

        [JsonPropertyName("policies.webApplicationFirewall.rateLimiting.failureDelayBaseMilliseconds")]
        Policies_WebApplicationFirewall_RateLimiting_FailureDelayBaseMilliseconds,

        [JsonPropertyName("policies.webApplicationFirewall.rateLimiting.failureDelayMaximumMilliseconds")]
        Policies_WebApplicationFirewall_RateLimiting_FailureDelayMaximumMilliseconds,

        // Web Application Firewall - Whitelisting
        [JsonPropertyName("policies.webApplicationFirewall.whitelisting.whitelistedIps")]
        Policies_WebApplicationFirewall_Whitelisting_WhitelistedIps,

        // Web Application Firewall - Distributed Attack Detection
        [JsonPropertyName("policies.webApplicationFirewall.distributedAttackDetection.ipThreshold")]
        Policies_WebApplicationFirewall_DistributedAttackDetection_IpThreshold,

        [JsonPropertyName("policies.webApplicationFirewall.distributedAttackDetection.windowInMinutes")]
        Policies_WebApplicationFirewall_DistributedAttackDetection_WindowInMinutes,

        // ####################################################################################################
        // Policies -> Password
        // ####################################################################################################
        [JsonPropertyName("policies.password.minimumLength")]
        Policies_Password_MinimumLength,

        [JsonPropertyName("policies.password.requireUppercase")]
        Policies_Password_RequireUppercase,

        [JsonPropertyName("policies.password.requireLowercase")]
        Policies_Password_RequireLowercase,

        [JsonPropertyName("policies.password.requireNumeric")]
        Policies_Password_RequireNumeric,

        [JsonPropertyName("policies.password.requireSpecialCharacter")]
        Policies_Password_RequireSpecialCharacter,

        // ####################################################################################################
        // Policies -> Account Lockout
        // ####################################################################################################
        [JsonPropertyName("policies.accountLockout.maximumFailedLoginAttempts")]
        Policies_AccountLockout_MaximumFailedLoginAttempts,

        [JsonPropertyName("policies.accountLockout.lockoutDurationInMinutes")]
        Policies_AccountLockout_LockoutDurationInMinutes,

        [JsonPropertyName("policies.accountLockout.resetFailedAttemptsAfterInMinutes")]
        Policies_AccountLockout_ResetFailedAttemptsAfterInMinutes,

        // ####################################################################################################
        // Policies -> Authentication
        // ####################################################################################################
        [JsonPropertyName("policies.authentication.preventPasswordReuse")]
        Policies_Authentication_PreventPasswordReuse,

        // ####################################################################################################
        // Policies -> Logging
        // ####################################################################################################
        // Logging - Security
        [JsonPropertyName("policies.logging.security.logSuccessfulLogins")]
        Policies_Logging_Security_LogSuccessfulLogins,

        [JsonPropertyName("policies.logging.security.logIncorrectPasswordLoginAttempts")]
        Policies_Logging_Security_LogIncorrectPasswordLoginAttempts,

        [JsonPropertyName("policies.logging.security.logIncorrectEmailAddressLoginAttempts")]
        Policies_Logging_Security_LogIncorrectEmailAddressLoginAttempts,

        [JsonPropertyName("policies.logging.security.logPasswordChanges")]
        Policies_Logging_Security_LogPasswordChanges,

        // Logging - Entity Actions - Cases
        [JsonPropertyName("policies.logging.entityActions.cases.logCreations")]
        Policies_Logging_EntityActions_Cases_LogCreations,

        [JsonPropertyName("policies.logging.entityActions.cases.logModifications")]
        Policies_Logging_EntityActions_Cases_LogModifications,

        [JsonPropertyName("policies.logging.entityActions.cases.logDeletions")]
        Policies_Logging_EntityActions_Cases_LogDeletions,

        // Logging - Entity Actions - Case Additional Properties
        [JsonPropertyName("policies.logging.entityActions.caseAdditionalProperties.logCreations")]
        Policies_Logging_EntityActions_CaseAdditionalProperties_LogCreations,

        [JsonPropertyName("policies.logging.entityActions.caseAdditionalProperties.logModifications")]
        Policies_Logging_EntityActions_CaseAdditionalProperties_LogModifications,

        [JsonPropertyName("policies.logging.entityActions.caseAdditionalProperties.logDeletions")]
        Policies_Logging_EntityActions_CaseAdditionalProperties_LogDeletions,

        // Logging - Entity Actions - Case Workers
        [JsonPropertyName("policies.logging.entityActions.caseWorkers.logAssignments")]
        Policies_Logging_EntityActions_CaseWorkers_LogAssignments,

        [JsonPropertyName("policies.logging.entityActions.caseWorkers.logUnAssignments")]
        Policies_Logging_EntityActions_CaseWorkers_LogUnAssignments,

        // Logging - Entity Actions - Case Clients
        [JsonPropertyName("policies.logging.entityActions.caseClients.logAssignments")]
        Policies_Logging_EntityActions_CaseClients_LogAssignments,

        [JsonPropertyName("policies.logging.entityActions.caseClients.logUnAssignments")]
        Policies_Logging_EntityActions_CaseClients_LogUnAssignments,

        // Logging - Entity Actions - Case Messages
        [JsonPropertyName("policies.logging.entityActions.caseMessages.logSends")]
        Policies_Logging_EntityActions_CaseMessages_LogSends,

        [JsonPropertyName("policies.logging.entityActions.caseMessages.logViews")]
        Policies_Logging_EntityActions_CaseMessages_LogViews,

        // Logging - Entity Actions - Case Files
        [JsonPropertyName("policies.logging.entityActions.caseFiles.logUploads")]
        Policies_Logging_EntityActions_CaseFiles_LogUploads,

        [JsonPropertyName("policies.logging.entityActions.caseFiles.logViews")]
        Policies_Logging_EntityActions_CaseFiles_LogViews,

        [JsonPropertyName("policies.logging.entityActions.caseFiles.logDeletions")]
        Policies_Logging_EntityActions_CaseFiles_LogDeletions,

        // Logging - Entity Actions - Case Todos
        [JsonPropertyName("policies.logging.entityActions.caseTodos.logCreations")]
        Policies_Logging_EntityActions_CaseTodos_LogCreations,

        [JsonPropertyName("policies.logging.entityActions.caseTodos.logModifications")]
        Policies_Logging_EntityActions_CaseTodos_LogModifications,

        [JsonPropertyName("policies.logging.entityActions.caseTodos.logDeletions")]
        Policies_Logging_EntityActions_CaseTodos_LogDeletions,

        // Logging - Entity Actions - Users
        [JsonPropertyName("policies.logging.entityActions.users.logCreations")]
        Policies_Logging_EntityActions_Users_LogCreations,

        [JsonPropertyName("policies.logging.entityActions.users.logModifications")]
        Policies_Logging_EntityActions_Users_LogModifications,

        [JsonPropertyName("policies.logging.entityActions.users.logDeletions")]
        Policies_Logging_EntityActions_Users_LogDeletions,

        // Logging - Entity Actions - User Additional Properties
        [JsonPropertyName("policies.logging.entityActions.userAdditionalProperties.logCreations")]
        Policies_Logging_EntityActions_UserAdditionalProperties_LogCreations,

        [JsonPropertyName("policies.logging.entityActions.userAdditionalProperties.logModifications")]
        Policies_Logging_EntityActions_UserAdditionalProperties_LogModifications,

        [JsonPropertyName("policies.logging.entityActions.userAdditionalProperties.logDeletions")]
        Policies_Logging_EntityActions_UserAdditionalProperties_LogDeletions,

        // Logging - Entity Actions - User Files
        [JsonPropertyName("policies.logging.entityActions.userFiles.logUploads")]
        Policies_Logging_EntityActions_UserFiles_LogUploads,

        [JsonPropertyName("policies.logging.entityActions.userFiles.logViews")]
        Policies_Logging_EntityActions_UserFiles_LogViews,

        [JsonPropertyName("policies.logging.entityActions.userFiles.logDeletions")]
        Policies_Logging_EntityActions_UserFiles_LogDeletions,

        // ####################################################################################################
        // Argon2 Configuration
        // ####################################################################################################
        [JsonPropertyName("argon2.memoryCost")]
        Argon2_MemoryCost,

        [JsonPropertyName("argon2.timeCost")]
        Argon2_TimeCost,

        [JsonPropertyName("argon2.parallelism")]
        Argon2_Parallelism,

        [JsonPropertyName("argon2.hashLength")]
        Argon2_HashLength,

        [JsonPropertyName("argon2.saltLength")]
        Argon2_SaltLength,

        // ####################################################################################################
        // MFA Configuration
        // ####################################################################################################
        [JsonPropertyName("mfa.totp.issuer")]
        Mfa_Totp_Issuer,

        [JsonPropertyName("mfa.totp.recoveryCode.groupSize")]
        Mfa_Totp_RecoveryCode_GroupSize,

        [JsonPropertyName("mfa.totp.recoveryCode.groupCount")]
        Mfa_Totp_RecoveryCode_GroupCount,

        // ####################################################################################################
        // Instance
        // ####################################################################################################
        [JsonPropertyName("instance.fqdn")]
        Instance_Fqdn,

        [JsonPropertyName("instance.branding.logoRelativePath")]
        Instance_Branding_LogoRelativePath,

        [JsonPropertyName("instance.branding.logoContrastRelativePath")]
        Instance_Branding_LogoContrastRelativePath,

        [JsonPropertyName("instance.branding.name")]
        Instance_Branding_Name,

        // contacts
        [JsonPropertyName("instance.contacts.firstPointOfContact.emailAddress")]
        Instance_Contacts_FirstPointOfContact_EmailAddress,

        [JsonPropertyName("instance.contacts.firstPointOfContact.phone.number")]
        Instance_Contacts_FirstPointOfContact_Phone_Number,

        [JsonPropertyName("instance.contacts.firstPointOfContact.phone.openingHours")]
        Instance_Contacts_FirstPointOfContact_Phone_OpeningHours,

        [JsonPropertyName("instance.contacts.firstPointOfContact.text.number")]
        Instance_Contacts_FirstPointOfContact_Text_Number,

        [JsonPropertyName("instance.contacts.firstPointOfContact.text.openingHours")]
        Instance_Contacts_FirstPointOfContact_Text_OpeningHours,

        [JsonPropertyName("instance.contacts.maintainer.name")]
        Instance_Contacts_Maintainer_Name,

        [JsonPropertyName("instance.contacts.maintainer.emailAddress")]
        Instance_Contacts_Maintainer_EmailAddress,

        [JsonPropertyName("instance.contacts.operator.name")]
        Instance_Contacts_Operator_Name,

        [JsonPropertyName("instance.contacts.operator.emailAddress")]
        Instance_Contacts_Operator_EmailAddress,

        [JsonPropertyName("instance.contacts.generalEnquiries.name")]
        Instance_Contacts_GeneralEnquiries_Name,

        [JsonPropertyName("instance.contacts.generalEnquiries.emailAddress")]
        Instance_Contacts_GeneralEnquiries_EmailAddress,

        // defaults
        [JsonPropertyName("instance.defaults.timeZone")]
        Instance_Defaults_TimeZone,

        [JsonPropertyName("instance.defaults.language")]
        Instance_Defaults_Language,

        // navigation
        [JsonPropertyName("instance.navigation.aboutPageRelativePath")]
        Instance_Navigation_AboutPageRelativePath,

        // ####################################################################################################
        // New Relic Configuration
        // ####################################################################################################
        [JsonPropertyName("newRelic.useNewRelic")]
        NewRelic_UseNewRelic,

        [JsonPropertyName("newRelic.key")]
        NewRelic_Key,

        // ####################################################################################################
        // Development Configuration
        // ####################################################################################################
        [JsonPropertyName("development.disableReCaptcha")]
        Development_DisableReCaptcha,

        [JsonPropertyName("development.phpAcceptSelfSignedCertificatesForApi")]
        Development_PhpAcceptSelfSignedCertificatesForApi
    }
}
