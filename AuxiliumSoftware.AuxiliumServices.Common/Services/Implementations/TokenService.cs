using AuxiliumSoftware.AuxiliumServices.Common.Configuration;
using AuxiliumSoftware.AuxiliumServices.Common.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class TokenService : ITokenService
{
    private readonly ConfigurationStructure _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration.Get<ConfigurationStructure>()!;
    }

    public string CreateMfaToken(Dictionary<string, object> userData)
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
            audience: _configuration.JWT.ValidAudiencePrefix + "/mfa",
            claims: claims,
            expires: DateTime.UtcNow.AddSeconds(_configuration.JWT.MfaTokenExpirationInSeconds),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public Guid? ValidateMfaToken(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration.JWT.ValidIssuer,
                ValidAudience = _configuration.JWT.ValidAudiencePrefix + "/mfa",
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration.JWT.SecretKey)
                ),
                ClockSkew = TimeSpan.Zero
            };

            var principal = tokenHandler.ValidateToken(token, validationParameters, out _);

            var subClaim = principal.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
                        ?? principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (Guid.TryParse(subClaim, out var userId))
            {
                return userId;
            }

            return null;
        }
        catch (SecurityTokenException)
        {
            return null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public string CreateAccessToken(Dictionary<string, object> userData)
    {
        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration.JWT.SecretKey));
        SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

        List<Claim> claims =
        [
            new(JwtRegisteredClaimNames.Sub, userData["id"].ToString()!),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new("token_type", "access"),
        ];

        JwtSecurityToken token = new(
            issuer: _configuration.JWT.ValidIssuer,
            audience: _configuration.JWT.ValidAudiencePrefix + "/access",
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
            audience: _configuration.JWT.ValidAudiencePrefix + "/refresh",
            claims: claims,
            expires: DateTime.UtcNow.AddDays(_configuration.JWT.RefreshTokenExpirationInDays),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
