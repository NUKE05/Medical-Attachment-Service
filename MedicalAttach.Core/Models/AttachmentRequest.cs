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
        public AttachmentRequest(Guid id, DateTime creationDate, DateTime processingDate, Guid patientId, string status)
        {
            Id = id;
            CreationDate = creationDate;
            ProcessingDate = processingDate;
            PatientId = patientId;
            Status = status;
        }

        public Guid Id { get; }
        public DateTime CreationDate { get; }
        public DateTime ProcessingDate { get; }
        public Guid PatientId { get; }
        public string Status { get; } = string.Empty;
    }
}
