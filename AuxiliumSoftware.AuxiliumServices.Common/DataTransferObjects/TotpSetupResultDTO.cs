namespace AuxiliumSoftware.AuxiliumServices.Common.DataTransferObjects
{
    public class TotpSetupResult
    {
        /// <summary>
        /// Raw base32 secret for manual entry into authenticator app.
        /// </summary>
        public string Secret { get; set; } = string.Empty;

        /// <summary>
        /// "otpauth://" URI for QR code generation.
        /// </summary>
        public string ProvisioningUri { get; set; } = string.Empty;
    }
}
