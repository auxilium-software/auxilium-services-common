using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels
{
    public class LogLoginAttemptEntityModel
    {
        /// <summary>
        /// The unique identifier for the Log Entry.
        /// </summary>
        public required Guid Id { get; set; }
        /// <summary>
        /// The timestamp of when the Log Entry was created.
        /// </summary>
        public required DateTime CreatedAt { get; set; }



        /// <summary>
        /// What Email Address was attempted during login.
        /// </summary>
        public required string AttemptedEmailAddress { get; set; }
        /// <summary>
        /// Whether the login attempt was successful.
        /// </summary>
        public required bool WasLoginSuccessful { get; set; }
    }
}
