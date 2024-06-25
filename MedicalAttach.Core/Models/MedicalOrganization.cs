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
        }

        public Guid Id { get; }
        public string Name { get; } = string.Empty;
    }
}
