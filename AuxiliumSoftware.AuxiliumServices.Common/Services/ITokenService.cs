namespace AuxiliumSoftware.AuxiliumServices.Common.Services
{
    public interface ITokenService
    {
        string CreateAccessToken(Dictionary<string, object> userData);
        string CreateRefreshToken(Dictionary<string, object> userData);
    }
}
