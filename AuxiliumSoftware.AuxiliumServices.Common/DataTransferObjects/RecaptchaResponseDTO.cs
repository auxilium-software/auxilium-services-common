namespace AuxiliumSoftware.AuxiliumServices.Common.DataTransferObjects
{
    /// <summary>
    /// Represents the response from a reCAPTCHA verification request.
    /// </summary>
    internal class RecaptchaResponseDTO
    {
        /// <summary>
        /// Whether the reCAPTCHA verification was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// The timestamp of the challenge.
        /// </summary>
        public DateTime ChallengeTs { get; set; }

        /// <summary>
        /// The hostname of the site where the reCAPTCHA was solved.
        /// </summary>
        public string? Hostname { get; set; }

        /// <summary>
        /// The score assigned by reCAPTCHA (v3 only).
        /// </summary>
        public double? Score { get; set; }

        /// <summary>
        /// The action name for reCAPTCHA (v3 only).
        /// </summary>
        public string? Action { get; set; }

        /// <summary>
        /// Any error codes returned by the reCAPTCHA service.
        /// </summary>
        public string[]? ErrorCodes { get; set; }
    }
}
