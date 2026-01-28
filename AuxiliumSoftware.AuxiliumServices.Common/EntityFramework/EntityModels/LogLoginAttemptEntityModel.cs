using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels
{
    public class LogLoginAttemptEntityModel
    {
        public required Guid Id { get; set; }
        public required DateTime CreatedAt { get; set; }



        public required string AttemptedEmailAddress { get; set; }
        public required bool WasLoginSuccessful { get; set; }
    }
}
