using AuxiliumSoftware.AuxiliumServices.Common.Configuration;
using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators;
using AuxiliumSoftware.AuxiliumServices.Common.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Policies
{
    public static class PasswordPolicy
    {
        public static async Task<(bool IsValid, List<string> Errors)> Validate(ISystemSettingsService systemSettings, string password)
        {
            var errors = new List<string>();

            if (password.Length < await systemSettings.GetIntAsync(SystemSettingKeyEnum.Policies_Password_MinimumLength))
                errors.Add($"Password must be at least {await systemSettings.GetIntAsync(SystemSettingKeyEnum.Policies_Password_MinimumLength)} characters");

            if (await systemSettings.GetBoolAsync(SystemSettingKeyEnum.Policies_Password_RequireUppercase) == true)
                if (!password.Any(char.IsUpper))
                    errors.Add("Password must contain an uppercase letter");

            if (await systemSettings.GetBoolAsync(SystemSettingKeyEnum.Policies_Password_RequireLowercase) == true)
                if (!password.Any(char.IsLower))
                    errors.Add("Password must contain a lowercase letter");


            if (await systemSettings.GetBoolAsync(SystemSettingKeyEnum.Policies_Password_RequireNumeric) == true)
                if (!password.Any(char.IsDigit))
                    errors.Add("Password must contain a number");

            if (await systemSettings.GetBoolAsync(SystemSettingKeyEnum.Policies_Password_RequireSpecialCharacter) == true)
                if (!password.Any(c => !char.IsLetterOrDigit(c)))
                    errors.Add("Password must contain a special character");

            return (errors.Count == 0, errors);
        }
    }
}
