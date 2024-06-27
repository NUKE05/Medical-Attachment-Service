using MedicalAttach.Core.Models;
using Microsoft.Identity.Client;
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

        public ICollection<UserEntity> Users { get; set; }
        public ICollection<AttachmentRequestEntity> AttachmentRequests { get; set; }
    }
}
