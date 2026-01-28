using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels
{
    public class LogSystemBulletinEntryViewEntityModel
    {
        public required Guid Id { get; set; }
        public required DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }



        public required Guid SystemBulletinId { get; set; }



        public UserEntityModel? CreatedByUser { get; set; }
        public SystemBulletinEntryEntityModel? SystemBulletin { get; set; }
    }
}
