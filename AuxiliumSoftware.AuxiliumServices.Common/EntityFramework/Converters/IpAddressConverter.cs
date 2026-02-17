using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Converters
{
    public class IpAddressConverter : ValueConverter<IPAddress, string>
    {
        public IpAddressConverter()
            : base(
                ip => ip.ToString(),
                str => IPAddress.Parse(str))
        { }
    }
}
