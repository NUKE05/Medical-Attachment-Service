using MedicalAttach.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAttach.DataAccess.Entities
{
    public class PatientEntity
    {
        public PatientEntity(Guid id, string lastName, string firstName, string middleName, string iIN, Guid medicalOrganizationId)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            IIN = iIN;
            MedicalOrganizationId = medicalOrganizationId;
        }

        public Guid Id { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string IIN { get; set; } = string.Empty;
        public Guid MedicalOrganizationId { get; set; }
        public MedicalOrganization MedicalOrganization { get; set; }
        public ICollection<AttachmentRequest> AttachmentRequests { get; set; }
    }
}
