namespace AuxiliumSoftware.AuxiliumServices.Common.Services.Interfaces
{
    public interface ICaptchaService
    {
        Task<bool> VerifyRecaptchaAsync(string token, string? clientIp);
    }
}
