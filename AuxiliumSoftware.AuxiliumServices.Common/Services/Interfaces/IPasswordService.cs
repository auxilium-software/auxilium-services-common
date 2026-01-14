namespace AuxiliumSoftware.AuxiliumServices.Common.Services.Interfaces
{
    public interface IPasswordService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string passwordHash);
    }
}
