using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumServices.Common.Configuration.Sections.Policies
{
    public class AccountLockoutPolicyConfigurationSection
    {
        public required int MaximumFailedLoginAttempts { get; set; }
        public required int LockoutDurationInMinutes { get; set; }
        public required int ResetDailedAttemptsAfterInMinutes { get; set; }
    }
}
