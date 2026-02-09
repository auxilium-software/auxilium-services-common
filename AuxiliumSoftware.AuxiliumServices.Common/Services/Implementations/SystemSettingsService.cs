using AuxiliumSoftware.AuxiliumServices.Common.Attributes;
using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework;
using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels;
using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Reflection;
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

        public async Task<dynamic> GetValueAsync(SystemSettingKeyEnum key)
        {
            var typeAttr = GetAttribute<SystemSettingExpectedValueTypeAttribute>(key);
            if (typeAttr is null)
                throw new InvalidOperationException($"No expected value type specified for key '{key}'");

            var setting = await _db.System_Settings
                .AsNoTracking()
                .Where(s => s.ConfigKey == key)
                .OrderByDescending(s => s.CreatedAt)
                .FirstOrDefaultAsync();

            if (setting is not null)
            {
                return DeserializeValue(setting.ConfigValue, typeAttr.ValueType);
            }

            var defaultAttr = GetAttribute<SystemSettingDefaultValueAttribute>(key);
            if (defaultAttr is null)
                throw new InvalidOperationException($"No value found in database for key '{key}' and no default attribute specified");

            if (typeAttr.ValueType == SystemSettingValueTypeEnum.StringArray)
            {
                var stringValue = defaultAttr.DefaultValue?.ToString() ?? "";
                return string.IsNullOrEmpty(stringValue)
                    ? new List<string>()
                    : stringValue.Split(',').Select(s => s.Trim()).ToList();
            }

            return defaultAttr.DefaultValue!;
        }


        public async Task<string> GetStringAsync(SystemSettingKeyEnum key)
        {
            var value = await GetValueAsync(key);
            return (string)value;
        }

        public async Task<int> GetIntAsync(SystemSettingKeyEnum key)
        {
            var value = await GetValueAsync(key);
            return Convert.ToInt32(value);
        }

        public async Task<bool> GetBoolAsync(SystemSettingKeyEnum key)
        {
            var value = await GetValueAsync(key);
            return (bool)value;
        }

        public async Task<List<string>> GetStringArrayAsync(SystemSettingKeyEnum key)
        {
            var value = await GetValueAsync(key);
            return (List<string>)value;
        }

        public async Task<T?> GetAsync<T>(SystemSettingKeyEnum key)
        {
            var value = await GetValueAsync(key);

            if (value is T typedValue)
                return typedValue;

            if (value is JsonElement jsonElement)
                return jsonElement.Deserialize<T>();

            return (T)Convert.ChangeType(value, typeof(T));
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

            _db.System_Settings.Add(new SystemSettingEntityModel
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


        private static dynamic DeserializeValue(string json, SystemSettingValueTypeEnum valueType)
        {
            return valueType switch
            {
                SystemSettingValueTypeEnum.String => JsonSerializer.Deserialize<string>(json)!,
                SystemSettingValueTypeEnum.Int => JsonSerializer.Deserialize<int>(json),
                SystemSettingValueTypeEnum.Bool => JsonSerializer.Deserialize<bool>(json),
                SystemSettingValueTypeEnum.Decimal => JsonSerializer.Deserialize<decimal>(json),
                SystemSettingValueTypeEnum.StringArray => JsonSerializer.Deserialize<List<string>>(json)!,
                SystemSettingValueTypeEnum.Json => JsonSerializer.Deserialize<JsonElement>(json),
                _ => throw new ArgumentOutOfRangeException(nameof(valueType), $"Unsupported value type: {valueType}")
            };
        }

        private static T? GetAttribute<T>(SystemSettingKeyEnum key) where T : Attribute
        {
            var memberInfo = typeof(SystemSettingKeyEnum)
                .GetField(key.ToString());

            return memberInfo?.GetCustomAttribute<T>();
        }

        private static SystemSettingValueTypeEnum InferValueType<T>(T value)
        {
            return value switch
            {
                string => SystemSettingValueTypeEnum.String,
                int or long => SystemSettingValueTypeEnum.Int,
                bool => SystemSettingValueTypeEnum.Bool,
                decimal or float or double => SystemSettingValueTypeEnum.Decimal,
                IEnumerable<string> => SystemSettingValueTypeEnum.StringArray,
                _ => SystemSettingValueTypeEnum.Json
            };
        }
    }
}
