using AuxiliumSoftware.AuxiliumServices.Common.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Policies
{
    public static class PasswordPolicy
    {
        public static (bool IsValid, List<string> Errors) Validate(ConfigurationStructure configuration, string password)
        {
            var errors = new List<string>();

            if (password.Length < configuration.Policies.PasswordPolicy.MinimumLength)
                errors.Add($"Password must be at least {configuration.Policies.PasswordPolicy.MinimumLength} characters");

            if (configuration.Policies.PasswordPolicy.Requirements.AtLeastOneUppercaseCharacter == true)
                if (!password.Any(char.IsUpper))
                    errors.Add("Password must contain an uppercase letter");

            if (configuration.Policies.PasswordPolicy.Requirements.AtLeastOneLowercaseCharacter == true)
                if (!password.Any(char.IsLower))
                    errors.Add("Password must contain a lowercase letter");


            if (configuration.Policies.PasswordPolicy.Requirements.AtLeastOneNumericCharacter == true)
                if (!password.Any(char.IsDigit))
                    errors.Add("Password must contain a number");

            if (configuration.Policies.PasswordPolicy.Requirements.AtLeastOneSpecialCharacter == true)
                if (!password.Any(c => !char.IsLetterOrDigit(c)))
                    errors.Add("Password must contain a special character");

            return (errors.Count == 0, errors);
        }
    }
}
