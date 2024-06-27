using System;
using System.Collections.Generic;

namespace MedicalAttach.DataAccess.Entities
{
    public class PatientEntity
    {
        public Guid Id { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string IIN { get; set; } = string.Empty;
        public ICollection<AttachmentRequestEntity> AttachmentRequests { get; set; }
    }
}
