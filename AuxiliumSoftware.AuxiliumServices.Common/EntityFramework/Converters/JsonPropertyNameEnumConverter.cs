using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection;
using System.Text.Json.Serialization;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Converters
{
    public class JsonPropertyNameEnumConverter<TEnum> : ValueConverter<TEnum?, string?>
            where TEnum : struct, Enum
    {
        public JsonPropertyNameEnumConverter() : base(
            v => v.HasValue ? EnumToString(v.Value) : null,
            v => v != null ? StringToEnum(v) : null,
            new ConverterMappingHints(unicode: true))
        {
        }

        private static string EnumToString(TEnum value)
        {
            var member = typeof(TEnum).GetMember(value.ToString()).FirstOrDefault();
            var attribute = member?.GetCustomAttribute<JsonPropertyNameAttribute>();
            return attribute?.Name ?? value.ToString();
        }

        private static TEnum StringToEnum(string value)
        {
            foreach (var field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var attribute = field.GetCustomAttribute<JsonPropertyNameAttribute>();
                if (attribute?.Name == value)
                {
                    return (TEnum)field.GetValue(null)!;
                }
            }
            return Enum.Parse<TEnum>(value);
        }
    }
}
