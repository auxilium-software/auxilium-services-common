using AuxiliumSoftware.AuxiliumServices.Common.Configuration;
using AuxiliumSoftware.AuxiliumServices.Common.Services.Interfaces;
using AuxiliumSoftware.AuxiliumServices.Common.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly ConfigurationStructure _configuration;
        public TokenService(
            IConfiguration configuration
            )
        {
            _configuration = configuration.Get<ConfigurationStructure>()!;
        }

        public string CreateAccessToken(Dictionary<string, object> userData)
        {
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration.JWT.SecretKey));
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims =
            [
                new(JwtRegisteredClaimNames.Sub, userData["id"].ToString()!),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            ];

            JwtSecurityToken token = new(
                issuer: _configuration.JWT.ValidIssuer,
                audience: _configuration.JWT.ValidAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_configuration.JWT.AccessTokenExpirationInMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string CreateRefreshToken(Dictionary<string, object> userData)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.JWT.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, userData["id"].ToString()!),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _configuration.JWT.ValidIssuer,
                audience: _configuration.JWT.ValidAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(_configuration.JWT.RefreshTokenExpirationInDays),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
