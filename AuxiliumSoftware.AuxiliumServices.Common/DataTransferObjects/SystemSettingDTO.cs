using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.DataTransferObjects
{
    public class SystemSettingDTO
    {
        public string Key { get; set; }
        public object? Value { get; set; }
        public SystemSettingValueTypeEnum ValueType { get; set; }
        public string? Description { get; set; }
        public string? Recommendation { get; set; }
    }
}
