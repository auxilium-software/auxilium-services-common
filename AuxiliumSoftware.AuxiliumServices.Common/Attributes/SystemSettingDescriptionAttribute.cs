using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class SystemSettingDescriptionAttribute : Attribute
    {
        public string Description { get; }

        public SystemSettingDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
