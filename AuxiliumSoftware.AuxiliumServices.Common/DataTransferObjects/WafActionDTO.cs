using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.DataTransferObjects
{
    public class WafActionDTO
    {
        public bool IsUserLocked { get; set; }
        public bool IsIpTemporarilyBlocked { get; set; }
        public bool IsIpPermanentlyBlocked { get; set; }
        public bool IsDistributedAttackDetected { get; set; }
        public string? Message { get; set; }
    }
}
