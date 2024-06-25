using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAttach.Core.Models
{
    public class MedicalOrganization
    {
        public MedicalOrganization() { }

        // Constructor with parameters
        public MedicalOrganization(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
