using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels
{
    public class SystemWafIpBlockEntityModel
    {
        /// <summary>
        /// The unique identifier for the IP Block.
        /// </summary>
        [Key]
        public required Guid Id { get; set; }

        /// <summary>
        /// The timestamp of when the IP Block was created.
        /// </summary>
        public required DateTime CreatedAt { get; set; }

        /// <summary>
        /// The unique identifier of the User who created the IP Block.
        /// </summary>
        public Guid? CreatedBy { get; set; }





        /// <summary>
        /// The IP Address that is blocked.
        /// </summary>
        public required string IpAddress { get; set; }

        /// <summary>
        /// A reason for why the IP Address was blocked, if applicable.
        /// </summary>
        public string? Reason { get; set; }

        /// <summary>
        /// Whether the IP Block is permanent (i.e. does not expire and has to be manually removed) or temporary (i.e. expires at a certain date and time).
        /// </summary>
        public required bool IsPermanent { get; set; }





        /// <summary>
        /// When the IP Block expires, if it is not permanent.
        /// This MUST be null if the IP Block is permanent.
        /// </summary>
        public DateTime? ExpiresAt { get; set; }

        /// <summary>
        /// For a temporary block, this denotes when the block was lifted (i.e. when the IP Block became inactive).
        /// This MUST be null if the IP Block is permanent.
        /// This MUST be null if the IP Block is temporary and has not yet been lifted.
        /// </summary>
        public DateTime? UnblockedAt { get; set; }

        /// <summary>
        /// The unique identifier of the User who lifted the block, if applicable.
        /// This MUST be null if the IP Block is permanent.
        /// This MUST be null if the IP Block is temporary and has not yet been lifted.
        /// </summary>
        public Guid? UnblockedBy { get; set; }





        public UserEntityModel? CreatedByUser { get; set; }
        public UserEntityModel? UnblockedByUser { get; set; }
    }
}
