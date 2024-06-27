using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAttach.Core.Models
{
    public class User
    {
        public User() { }
        public User(
            Guid id, 
            string login, 
            string password, 
            bool isAdmin, 
            Guid medicalOrganizationId)
        {
            Id = id;
            Login = login;
            Password = HashPassword(password);
            IsAdmin = isAdmin;
            MedicalOrganizationId = medicalOrganizationId;
        }

        public Guid Id { get; }
        public string Login { get; } = null!;
        public string Password { get; } = null!;
        public bool IsAdmin { get; }
        public Guid MedicalOrganizationId { get; }

        public static (User user, string error) Create(Guid id, string login, string password, bool isAdmin, Guid medicalOrganizationId)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                error = "Логин и пароль не могут быть пустыми";
            }

            var user = new User(id, login, password, isAdmin, medicalOrganizationId);

            return (user, error);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    } 
}
