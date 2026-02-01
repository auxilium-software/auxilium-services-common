using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels
{
    public class TotpSecretEntityModel
    {
        /// <summary>
        /// The unique identifier for the TOTP Secret.
        /// </summary>
        [Key]
        public required Guid Id { get; set; }
        
        /// <summary>
        /// The timestamp of when the TOTP Secret was created.
        /// </summary>
        public required DateTime CreatedAt { get; set; }
        
        /// <summary>
        /// The unique identifier of the TOTP Secret who created the Case.
        /// </summary>
        public Guid? CreatedBy { get; set; }





        /// <summary>
        /// The shared TOTP secret, this MUST be encrypted by IDataProtector.
        /// </summary>
        public string EncryptedSecret { get; set; } = string.Empty;

        /// <summary>
        /// When the TOTP Code was first verified/used.
        /// </summary>
        public DateTime? FirstVerificationAt { get; set; }
    }
}
