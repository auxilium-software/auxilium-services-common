using AuxiliumSoftware.AuxiliumServices.Common.Configuration;
using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators;
using AuxiliumSoftware.AuxiliumServices.Common.Services.Interfaces;

namespace AuxiliumSoftware.AuxiliumServices.Common.Policies
{
    public static class AccountLockoutPolicy
    {
        public static async Task<bool> IsAccountLocked(ISystemSettingsService systemSettings, int failedLoginAttempts, DateTime? lockoutStartTime)
        {
            if (failedLoginAttempts < await systemSettings.GetIntAsync(SystemSettingKeyEnum.Policies_AccountLockout_MaximumFailedLoginAttempts))
                return false;

            if (lockoutStartTime == null)
                return false;

            // locked... but has the lockout period expired?
            return !(await IsLockoutPeriodOver(systemSettings, lockoutStartTime.Value));
        }

        public static async Task<bool> IsLockoutPeriodOver(ISystemSettingsService systemSettings, DateTime lockoutStartTime)
        {
            return DateTime.UtcNow >= lockoutStartTime.AddMinutes((double)await systemSettings.GetIntAsync(SystemSettingKeyEnum.Policies_AccountLockout_LockoutDurationInMinutes));
        }

        public static async Task<bool> ShouldResetFailedAttempts(ISystemSettingsService systemSettings, DateTime lastFailedAttemptTime)
        {
            return DateTime.UtcNow >= lastFailedAttemptTime.AddMinutes((double)await systemSettings.GetIntAsync(SystemSettingKeyEnum.Policies_AccountLockout_ResetFailedAttemptsAfterInMinutes));
        }

        public static async Task<int> GetEffectiveFailedAttempts(ISystemSettingsService systemSettings, int failedLoginAttempts, DateTime? lastFailedAttemptTime)
        {
            if (lastFailedAttemptTime == null)
                return 0;

            if (await ShouldResetFailedAttempts(systemSettings, lastFailedAttemptTime.Value))
                return 0;

            return failedLoginAttempts;
        }
    }
}
