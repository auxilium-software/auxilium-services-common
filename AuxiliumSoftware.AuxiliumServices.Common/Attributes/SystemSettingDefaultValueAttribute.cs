using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators;
using System;

namespace AuxiliumSoftware.AuxiliumServices.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class SystemSettingDefaultValueAttribute : Attribute
    {
        public object DefaultValue { get; }

        public SystemSettingDefaultValueAttribute(object defaultValue)
        {
            DefaultValue = defaultValue;
        }
    }
}
