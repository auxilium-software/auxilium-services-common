using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework;
using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels;
using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators;
using AuxiliumSoftware.AuxiliumServices.Common.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AuxiliumSoftware.AuxiliumServices.Common.Services.Implementations
{
    public class SystemSettingsService : ISystemSettingsService
    {
        private readonly AuxiliumDbContext _db;

        public SystemSettingsService(AuxiliumDbContext db)
        {
            _db = db;
        }



        public async Task<string> GetStringAsync(SystemSettingKeyEnum key)
        {
            var value = await GetRawValueAsync(key);
            return JsonSerializer.Deserialize<string>(value)!;
        }

        public async Task<int> GetIntAsync(SystemSettingKeyEnum key)
        {
            var value = await GetRawValueAsync(key);
            return JsonSerializer.Deserialize<int>(value);
        }

        public async Task<bool> GetBoolAsync(SystemSettingKeyEnum key)
        {
            var value = await GetRawValueAsync(key);
            return JsonSerializer.Deserialize<bool>(value);
        }

        public async Task<List<string>> GetStringArrayAsync(SystemSettingKeyEnum key)
        {
            var value = await GetRawValueAsync(key);
            return JsonSerializer.Deserialize<List<string>>(value)!;
        }

        public async Task<T?> GetAsync<T>(SystemSettingKeyEnum key)
        {
            var value = await GetRawValueAsync(key);
            return JsonSerializer.Deserialize<T>(value);
        }





        public async Task SetAsync<T>(
            SystemSettingKeyEnum key,
            T value,
            Guid? modifiedBy,
            string reasonForModification
        )
        {
            var jsonValue = JsonSerializer.Serialize(value);
            var valueType = InferValueType(value);

            _db.SystemSettings.Add(new SystemSettingEntityModel
            {
                Id = Guid.NewGuid(),
                ConfigKey = key,
                ConfigValue = jsonValue,
                ValueType = valueType,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = modifiedBy,
                ReasonForModification = reasonForModification
            });

            await _db.SaveChangesAsync();
        }




        private async Task<string> GetRawValueAsync(SystemSettingKeyEnum key)
        {
            var setting = await _db.SystemSettings
                .AsNoTracking()
                .OrderBy(s => s.CreatedAt)
                .LastOrDefaultAsync(s => s.ConfigKey == key);

            return setting is null ? throw new Exception($"No setting found for key: {key}") : setting.ConfigValue;
        }

        private static SystemSettingValueTypeEnum InferValueType<T>(T value)
        {
            return value switch
            {
                string                      => SystemSettingValueTypeEnum.String,
                int or long                 => SystemSettingValueTypeEnum.Int,
                bool                        => SystemSettingValueTypeEnum.Bool,
                decimal or float or double  => SystemSettingValueTypeEnum.Decimal,
                IEnumerable<string>         => SystemSettingValueTypeEnum.StringArray,
                _                           => SystemSettingValueTypeEnum.Json
            };
        }
    }
}
