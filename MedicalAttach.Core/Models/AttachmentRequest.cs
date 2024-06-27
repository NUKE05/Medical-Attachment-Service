using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAttach.Core.Models
{
    public class AttachmentRequest
    {
        public AttachmentRequest() { }
        public AttachmentRequest(Guid id, DateTime creationDate, DateTime processingDate, Guid patientId, Guid medicalOrganizationId,string status)
        {
            Id = id;
            CreationDate = creationDate;
            ProcessingDate = processingDate;
            PatientId = patientId;
            MedicalOrganizationId = medicalOrganizationId;
            Status = status;
        }

        public Guid Id { get; }
        public DateTime CreationDate { get; }
        public DateTime ProcessingDate { get; }
        public Guid PatientId { get; }
        public Guid MedicalOrganizationId { get; }
        public string Status { get; } = string.Empty;
    }
}
