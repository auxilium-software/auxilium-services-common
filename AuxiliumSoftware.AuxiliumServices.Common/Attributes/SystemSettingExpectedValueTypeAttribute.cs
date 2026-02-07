using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Attributes
{
    internal class SystemSettingExpectedValueTypeAttribute : Attribute
    {
        public SystemSettingValueTypeEnum ValueType { get; }

        public SystemSettingExpectedValueTypeAttribute(SystemSettingValueTypeEnum valueType)
        {
            ValueType = valueType;
        }
    }
}
