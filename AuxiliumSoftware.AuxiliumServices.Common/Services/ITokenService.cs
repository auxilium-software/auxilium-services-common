namespace AuxiliumSoftware.AuxiliumServices.Common.Services
{
    public interface ITokenService
    {
        string CreateMfaToken(Dictionary<string, object> userData);
        Guid? ValidateMfaToken(string token);
        string CreateAccessToken(Dictionary<string, object> userData);
        string CreateRefreshToken(Dictionary<string, object> userData);
    }
}
