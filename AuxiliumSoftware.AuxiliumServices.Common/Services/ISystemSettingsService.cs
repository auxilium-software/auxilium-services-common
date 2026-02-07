using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuxiliumSoftware.AuxiliumServices.Common.Services.Interfaces
{
    public interface ISystemSettingsService
    {
        public Task<string> GetStringAsync(SystemSettingKeyEnum key);
        public Task<int> GetIntAsync(SystemSettingKeyEnum key);
        public Task<bool> GetBoolAsync(SystemSettingKeyEnum key);
        public Task<List<string>> GetStringArrayAsync(SystemSettingKeyEnum key);
        public Task<T?> GetAsync<T>(SystemSettingKeyEnum key);

        public Task SetAsync<T>(
            SystemSettingKeyEnum key,
            T value,
            Guid? modifiedBy,
            string reasonForModification
        );
    }
}
