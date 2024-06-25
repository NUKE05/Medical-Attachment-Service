using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAttach.Core.Models
{
    public class User
    {
        public User(Guid id, string login, string password, bool isAdmin, MedicalOrganization medicalOrganization)
        {
            Id = id;
            Login = login;
            Password = password;
            IsAdmin = isAdmin;
            MedicalOrganization = medicalOrganization;
        }

        public Guid Id { get; }
        public string Login { get; } = string.Empty;
        public string Password { get; } = string.Empty;
        public bool IsAdmin { get; }
        public MedicalOrganization MedicalOrganization { get; }

    }
}
