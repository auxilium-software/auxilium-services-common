using System;

namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels
{
    public class CaseAdditionalPropertyEntityModel
    {
        /// <summary>
        /// The unique identifier for the Additional Property.
        /// </summary>
        public required Guid Id { get; set; }
        /// <summary>
        /// The timestamp of when the Additional Property was created.
        /// </summary>
        public required DateTime CreatedAt { get; set; }
        /// <summary>
        /// The unique identifier of the user who created the Additional Property.
        /// </summary>
        public Guid? CreatedBy { get; set; }
        /// <summary>
        /// The timestamp of when the Additional Property was last updated.
        /// </summary>
        public DateTime? LastUpdatedAt { get; set; }
        /// <summary>
        /// The unique identifier of the user who last updated the Additional Property.
        /// </summary>
        public Guid? LastUpdatedBy { get; set; }





        /// <summary>
        /// The unique identifier of the Case the Additional Property is for.
        /// </summary>
        public required Guid CaseId { get; set; }
        /// <summary>
        /// The name of the Additional Property.
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// The MIME type of the Additional Property.
        /// </summary>
        /// <example>
        /// text/plain
        /// </example>
        /// <example>
        /// application/json
        /// </example>
        public required string ContentType { get; set; }
        /// <summary>
        /// The actual content of the Additional Property.
        /// </summary>
        public required string Content { get; set; }





        /// <summary>
        /// The User who created the Additional Property.
        /// </summary>
        public UserEntityModel? CreatedByUser { get; set; }
        /// <summary>
        /// The User who last updated the Additional Property.
        /// </summary>
        public UserEntityModel? LastUpdatedByUser { get; set; }
        /// <summary>
        /// The Case the Additional Property is for.
        /// </summary>
        public CaseEntityModel? Case { get; set; }
    }
}
