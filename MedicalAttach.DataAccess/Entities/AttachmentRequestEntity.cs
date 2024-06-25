using MedicalAttach.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAttach.DataAccess.Entities
{
    public class AttachmentRequestEntity
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ProcessingDate { get; set; }
        public required Patient Patient { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
