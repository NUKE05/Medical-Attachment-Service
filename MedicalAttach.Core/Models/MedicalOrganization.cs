using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAttach.Core.Models
{
    public class MedicalOrganization
    {
        public MedicalOrganization(Guid id,
                                   string name)
        {
            Id = id;
            Name = name;
            Patients = new List<Patient>();
            Users = new List<User>();
            AttachmentRequests = new List<AttachmentRequest>();
        }

        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public ICollection<Patient> Patients { get; }
        public ICollection<User> Users { get; }
        public ICollection<AttachmentRequest> AttachmentRequests { get; }
    }
}
