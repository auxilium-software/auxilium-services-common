using AuxiliumSoftware.AuxiliumServices.Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Services
{
    public interface ITotpService
    {
        Task<TotpSetupResultDTO> CreateSetupAsync(Guid userId, string userEmail);
        Task<TotpEnableResultDTO?> EnablePendingAsync(Guid userId, string code);
        Task<bool> DisableAsync(Guid userId, string code);
        Task<bool> ValidateUserTotpAsync(Guid userId, string? code);
        Task<bool> ValidateRecoveryCodeAsync(Guid userId, string? code);
        Task<List<string>?> RegenerateRecoveryCodesAsync(Guid userId, string totpCode);
        Task<int> GetRemainingRecoveryCodeCountAsync(Guid userId);
        Task<bool> IsTotpEnabledAsync(Guid userId);
        Task<bool> HasPendingSetupAsync(Guid userId);
    }
}
