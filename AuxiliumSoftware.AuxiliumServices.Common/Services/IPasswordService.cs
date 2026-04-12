namespace AuxiliumSoftware.AuxiliumServices.Common.Services
{
    public interface IPasswordService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string passwordHash);
        string NormalisePassword(string? rawPassword, string? passwordSha512);
    }
}
