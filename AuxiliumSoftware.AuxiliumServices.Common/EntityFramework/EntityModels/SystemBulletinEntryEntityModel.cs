using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels
{
    public class SystemBulletinEntryEntityModel
    {
        public required Guid Id { get; set; }
        public required DateTime CreatedAt { get; set; }
        public Guid? CreatedBy { get; set; }



        public required SystemBulletinMessageSeverityEnum Severity { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required bool IsActive { get; set; }
        public required bool IsDismissable { get; set; }
        public required DateTime StartsAt { get; set; }
        public DateTime? EndsAt { get; set; }
        public SystemBulletinMessageTargetAudienceEnum TargetAudience { get; set; }
        public Guid? SpecificUserId { get; set; }



        public UserEntityModel? CreatedByUser { get; set; }
        public UserEntityModel? SpecificUser { get; set; }
        public ICollection<LogSystemBulletinEntryDismissalEntityModel>? Dismissals { get; set; }
        public ICollection<LogSystemBulletinEntryViewEntityModel>? Views { get; set; }
    }
}
