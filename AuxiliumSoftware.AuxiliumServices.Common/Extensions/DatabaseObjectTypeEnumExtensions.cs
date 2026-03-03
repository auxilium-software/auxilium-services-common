using AuxiliumSoftware.AuxiliumServices.Common.Enumerators;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace AuxiliumSoftware.AuxiliumServices.Common.Extensions
{
    public static class DatabaseObjectTypeEnumExtensions
    {
        public static string ToPolicyString(this DatabaseObjectTypeEnum type)
        {
            var field = typeof(DatabaseObjectTypeEnum).GetField(type.ToString());
            var attr = field?.GetCustomAttribute<JsonPropertyNameAttribute>();
            return attr?.Name ?? type.ToString();
        }
    }
}
