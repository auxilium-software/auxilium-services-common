using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Net;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Converters;

public class IpAddressConverter : ValueConverter<IPAddress, string>
{
    public IpAddressConverter() : base(
        ip => (ip.IsIPv4MappedToIPv6 ? ip.MapToIPv4() : ip).ToString(),
        str => IPAddress.Parse(str)
    )
    { }
}
