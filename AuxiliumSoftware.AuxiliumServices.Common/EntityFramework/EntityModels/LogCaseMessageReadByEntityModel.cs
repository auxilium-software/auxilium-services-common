namespace AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels
{
    public class LogCaseMessageReadByEntityModel
    {
        /// <summary>
        /// The unique identifier for the additional property.
        /// </summary>
        public required Guid Id { get; set; }
        /// <summary>
        /// The timestamp when the additional property was created.
        /// </summary>
        public required DateTime CreatedAt { get; set; }
        /// <summary>
        /// The unique identifier of the user who created the additional property.
        /// </summary>
        public Guid CreatedBy { get; set; }



        /// <summary>
        /// The unique identifier for the message that has been read.
        /// </summary>
        public required Guid MessageId { get; set; }



        public UserEntityModel? CreatedByUser { get; set; }
        public CaseMessageEntityModel? Message { get; set; }
    }
}
