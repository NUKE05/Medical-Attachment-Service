using MedicalAttach.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAttach.DataAccess.Entities
{
    public class MedicalOrganizationEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public required ICollection<Patient> Patients { get; set; }
        public required ICollection<User> Users { get; set; }
        public required ICollection<AttachmentRequest> AttachmentRequests { get; set; }
    }
}
