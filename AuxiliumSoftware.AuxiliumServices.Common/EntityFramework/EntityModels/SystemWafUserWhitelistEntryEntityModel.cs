using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels
{
    public class SystemWafUserWhitelistEntryEntityModel
    {
        /// <summary>
        /// The unique identifier for the User Whitelist Entry.
        /// </summary>
        [Key]
        public required Guid Id { get; set; }
        /// <summary>
        /// The timestamp of when the User Whitelist Entry was created.
        /// </summary>
        public required DateTime CreatedAt { get; set; }
        /// <summary>
        /// The unique identifier of the user who created the User Whitelist Entry.
        /// </summary>
        public Guid? CreatedBy { get; set; }





        /// <summary>
        /// The User to be Whitelisted.
        /// </summary>
        public required Guid UserId { get; set; }





        public UserEntityModel? CreatedByUser { get; set; }
    }
}
