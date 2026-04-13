using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class SystemSettingVisibilityAttribute : Attribute
    {
        public SystemSettingVisibilityEnum Visibility { get; } = SystemSettingVisibilityEnum.Administrator;

        public SystemSettingVisibilityAttribute(SystemSettingVisibilityEnum visibility = SystemSettingVisibilityEnum.Administrator)
        {
            Visibility = visibility;
        }
    }
}
