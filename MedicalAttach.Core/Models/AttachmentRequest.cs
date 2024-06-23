using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAttach.Core.Models
{
    public class AttachmentRequest
    {
        public AttachmentRequest(Guid id, DateTime creationDate, DateTime processingDate, Patient patient, string status, Guid patientId)
        {
            Id = id;
            CreationDate = creationDate;
            ProcessingDate = processingDate;
            Patient = patient;
            Status = status;
            PatientId = patientId;
        }

        public Guid Id { get; }
        public DateTime CreationDate { get; }
        public DateTime ProcessingDate { get; }
        public Guid PatientId { get; }
        public Patient Patient { get; }
        public string Status { get; } = string.Empty;
    }
}
