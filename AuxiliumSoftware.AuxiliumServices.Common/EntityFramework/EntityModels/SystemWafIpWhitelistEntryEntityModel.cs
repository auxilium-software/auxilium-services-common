using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels
{
    public class SystemWafIpWhitelistEntryEntityModel
    {
        /// <summary>
        /// The unique identifier for the IP Address Whitelist Entry.
        /// </summary>
        [Key]
        public required Guid Id { get; set; }
        /// <summary>
        /// The timestamp of when the IP Address Whitelist Entry was created.
        /// </summary>
        public required DateTime CreatedAt { get; set; }
        /// <summary>
        /// The unique identifier of the user who created the IP Address Whitelist Entry.
        /// </summary>
        public Guid? CreatedBy { get; set; }





        /// <summary>
        /// The IP Address to be Whitelisted.
        /// </summary>
        public required IPAddress IpAddress { get; set; }
        /// <summary>
        /// A reason for this IP Address to be Whitelisted.
        /// </summary>
        public required string Justification { get; set; }





        public UserEntityModel? CreatedByUser { get; set; }
    }
}
