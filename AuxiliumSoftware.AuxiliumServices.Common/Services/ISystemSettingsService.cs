using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuxiliumSoftware.AuxiliumServices.Common.Services
{
    public interface ISystemSettingsService
    {
        public Task<string> GetStringAsync(SystemSettingKeyEnum key, CancellationToken ct);
        public Task<int> GetIntAsync(SystemSettingKeyEnum key, CancellationToken ct);
        public Task<bool> GetBoolAsync(SystemSettingKeyEnum key, CancellationToken ct);
        // public Task<T?> GetAsync<T>(SystemSettingKeyEnum key, CancellationToken ct);

        public Task SetAsync<T>(
            SystemSettingKeyEnum key,
            T value,
            Guid? modifiedBy,
            string reasonForModification,
            CancellationToken ct
        );
    }
}
