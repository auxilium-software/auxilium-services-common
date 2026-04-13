using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels
{
    public class PasswordSetTokenEntityModel
    {
        /// <summary>
        /// </summary>
        [Key]
        public required Guid Id { get; set; }
        /// <summary>
        /// </summary>
        public required DateTime CreatedAt { get; set; }
        /// <summary>
        /// </summary>
        public required Guid CreatedBy { get; set; }
        /// <summary>
        /// </summary>
        public required Guid UserId { get; set; }
        /// <summary>
        /// </summary>
        public required string TokenHash { get; set; }
        /// <summary>
        /// </summary>
        public required DateTime ExpiresAt { get; set; }
        /// <summary>
        /// </summary>
        public required DateTime? UsedAt { get; set; } = null;
        /// <summary>
        /// </summary>
        public required PasswordSetTokenReasonEnum Reason { get; set; }





        /// <summary>
        /// </summary>
        public UserEntityModel? CreatedByUser { get; set; }
        /// <summary>
        /// </summary>
        public UserEntityModel? User { get; set; }
    }
}
