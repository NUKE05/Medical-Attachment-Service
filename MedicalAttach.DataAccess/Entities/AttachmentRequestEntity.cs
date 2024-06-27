using System;

namespace MedicalAttach.DataAccess.Entities
{
    public class AttachmentRequestEntity
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ProcessingDate { get; set; }
        public required Guid PatientId { get; set; }
        public required Guid MedicalOrganizationId { get; set; }
        public string Status { get; set; } = string.Empty;

        public PatientEntity Patient { get; set; }
        public MedicalOrganizationEntity MedicalOrganization { get; set; }
    }
}
