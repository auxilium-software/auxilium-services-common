using AuxiliumSoftware.AuxiliumServices.Common.DataTransferObjects;
using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels;
using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Services
{
    public interface IWebApplicationFirewallService
    {
        public string NormalizeIpAddress(IPAddress ipAddress);





        Task<SystemWafIpBlacklistEntryEntityModel?> IsIpAddressBlacklistedAsync(IPAddress ipAddress, CancellationToken ct = default);
        Task<bool> IsIpAddressRateLimitedAsync(IPAddress ipAddress, CancellationToken ct = default);
        Task<SystemWafUserBlacklistEntryEntityModel?> IsUserBlacklistedAsync(UserEntityModel user, CancellationToken ct = default);
        Task<SystemWafUserBlacklistEntryEntityModel?> ApplyLockoutIfNeededAsync(UserEntityModel user, CancellationToken ct = default);





        Task<WebApplicationFirewallActionDTO> RecordFailedLoginAsync(
            IPAddress ipAddress,
            string attemptedEmail,
            UserEntityModel? user,
            LoginAttemptFailureReasonEnum failureReason,
            CancellationToken ct = default
        );
        Task RecordSuccessfulLoginAsync(
            IPAddress ipAddress,
            string email,
            UserEntityModel user,
            CancellationToken ct = default
        );
        Task<int> GetFailureDelayAsync(IPAddress ipAddress, CancellationToken ct = default);





        Task BlacklistIpAddressAsync(
            IPAddress ipAddress,
            string reason,
            UserEntityModel adminUser,
            bool permanent = true,
            CancellationToken ct = default
        );
        Task<bool> RemoveIpAddressFromBlacklistAsync(IPAddress ipAddress, UserEntityModel adminUser, CancellationToken ct = default);
        Task BlacklistUserAsync(
            UserEntityModel user,
            string reason,
            UserEntityModel adminUser,
            bool permanent = true,
            CancellationToken ct = default
        );
        Task<bool> RemoveUserFromBlacklist(UserEntityModel user, UserEntityModel adminUser, CancellationToken ct = default);





        Task WhitelistIpAddressAsync(
            IPAddress ipAddress,
            string reason,
            UserEntityModel adminUser,
            bool permanent = true,
            CancellationToken ct = default
        );
        Task<bool> RemoveIpAddressFromWhitelistAsync(IPAddress ipAddress, UserEntityModel adminUser, CancellationToken ct = default);
        Task WhitelistUserAsync(
            UserEntityModel user,
            string reason,
            UserEntityModel adminUser,
            bool permanent = true,
            CancellationToken ct = default
        );
        Task<bool> RemoveUserFromWhitelistAsync(UserEntityModel user, UserEntityModel adminUser, CancellationToken ct = default);





        Task<List<SystemWafIpBlacklistEntryEntityModel>> GetBlacklistedIpAddressesAsync(bool includeExpired = false, CancellationToken ct = default);
        Task<bool> IsWhitelistedAsync(IPAddress ipAddress, CancellationToken ct = default);





        Task<List<LogLoginAttemptEventEntityModel>> GetRecentLoginAttemptsAsync(
            int count = 100,
            string? ipFilter = null,
            Guid? userIdFilter = null,
            bool? successFilter = null,
            CancellationToken ct = default);
    }
}
