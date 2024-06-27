using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAttach.Core.Models
{
    public class MedicalOrganization
    {
        const decimal MIN_MEDICAL_ORGANIZATION_LENGTH = 5; // Минимальное количество символов для медицинской организации
        public MedicalOrganization() { }

        // Constructor with parameters
        public MedicalOrganization(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public static (MedicalOrganization medicalOrganization, string error) Create(Guid id, string name)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name) || name.Length < MIN_MEDICAL_ORGANIZATION_LENGTH)
            {
                error = "Название организации должно содержать больше 5 символов";
            }

            var medicalOrganization = new MedicalOrganization(id, name);

            return (medicalOrganization, error);
        }
    }
}
