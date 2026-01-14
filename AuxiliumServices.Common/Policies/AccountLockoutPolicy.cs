using AuxiliumSoftware.AuxiliumServices.Common.Configuration;

namespace AuxiliumSoftware.AuxiliumServices.Common.Policies
{
    public static class AccountLockoutPolicy
    {
        public static bool IsAccountLocked(ConfigurationStructure configuration, int failedLoginAttempts, DateTime? lockoutStartTime)
        {
            if (failedLoginAttempts < configuration.Policies.AccountLockoutPolicy.MaximumFailedLoginAttempts)
                return false;

            if (lockoutStartTime == null)
                return false;

            // locked... but has the lockout period expired?
            return !IsLockoutPeriodOver(configuration, lockoutStartTime.Value);
        }

        public static bool IsLockoutPeriodOver(ConfigurationStructure configuration, DateTime lockoutStartTime)
        {
            return DateTime.UtcNow >= lockoutStartTime.AddMinutes(configuration.Policies.AccountLockoutPolicy.LockoutDurationInMinutes);
        }

        public static bool ShouldResetFailedAttempts(ConfigurationStructure configuration, DateTime lastFailedAttemptTime)
        {
            return DateTime.UtcNow >= lastFailedAttemptTime.AddMinutes(configuration.Policies.AccountLockoutPolicy.ResetFailedAttemptsAfterInMinutes);
        }

        public static int GetEffectiveFailedAttempts(ConfigurationStructure configuration, int failedLoginAttempts, DateTime? lastFailedAttemptTime)
        {
            if (lastFailedAttemptTime == null)
                return 0;

            if (ShouldResetFailedAttempts(configuration, lastFailedAttemptTime.Value))
                return 0;

            return failedLoginAttempts;
        }
    }
}
