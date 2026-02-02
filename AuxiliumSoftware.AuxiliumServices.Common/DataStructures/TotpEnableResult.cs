
namespace AuxiliumSoftware.AuxiliumServices.Common.DataStructures
{
    public class TotpEnableResult
    {
        /// <summary>
        /// Plaintext Recovery Codes.
        /// Show these to the user ONCE - these are stored as SHA256 hashes and cannot be seen in plain-text again.
        /// </summary>
        public List<string> RecoveryCodes { get; set; } = new();
    }
}
