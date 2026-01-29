namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels
{
    public class CaseTimelineItemEntityModel
    {
        /// <summary>
        /// The unique identifier for the Case Timeline Item.
        /// </summary>
        public required Guid Id { get; set; }
        /// <summary>
        /// The unique identifier for the case associated with the Case Timeline Item.
        /// </summary>
        public required Guid CaseId { get; set; }
        /// <summary>
        /// The timestamp of when the Case Timeline Item was created.
        /// </summary>
        public required DateTime CreatedAt { get; set; }
        /// <summary>
        /// The unique identifier of the user who created the Case Timeline Item.
        /// </summary>
        public Guid? CreatedBy { get; set; }
        /// <summary>
        /// The timestamp of when the Case Timeline Item was last updated.
        /// </summary>
        public DateTime? LastUpdatedAt { get; set; }
        /// <summary>
        /// The unique identifier of the user who last updated the Case Timeline Item.
        /// </summary>
        public Guid? LastUpdatedBy { get; set; }





        /// <summary>
        /// The Case the Case Timeline Item is for.
        /// </summary>
        public CaseEntityModel? Case { get; set; }
        /// <summary>
        /// The User who created the Case Timeline Item.
        /// </summary>
        public UserEntityModel? CreatedByUser { get; set; }
        /// <summary>
        /// The User who last updated the Case Timeline Item.
        /// </summary>
        public UserEntityModel? LastUpdatedByUser { get; set; }
    }
}
