using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAttach.Core.Models
{
    public class Patient
    {
        public Patient(Guid id,
                       string lastName,
                       string firstName,
                       string middleName,
                       string iin,
                       Guid medicalOrganizationId)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            IIN = iin;
            MedicalOrganizationId = medicalOrganizationId;
        }

        public Guid Id { get; }
        public string LastName { get; } = string.Empty;
        public string FirstName { get; } = string.Empty;
        public string MiddleName { get; } = string.Empty;
        public string IIN { get; } = string.Empty;
        public Guid MedicalOrganizationId { get; }
        public MedicalOrganization MedicalOrganization { get; set; }
        public ICollection<AttachmentRequest> AttachmentRequests { get; set; }
    }
}
