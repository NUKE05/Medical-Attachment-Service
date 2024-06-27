using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAttach.Core.Models
{
    public class Patient
    {
        public Patient() { }
        public Patient(Guid id,
                       string lastName,
                       string firstName,
                       string middleName,
                       string iin)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            IIN = iin;
        }

        public Guid Id { get; set; }
        public string LastName { get; } = string.Empty;
        public string FirstName { get; } = string.Empty;
        public string MiddleName { get; } = string.Empty;
        public string IIN { get; } = string.Empty;

        public static (Patient Patient, string error) Create(Guid id, string lastName, string firstName, string middleName, string iin)
        {
            var error = string.Empty;


            if (lastName.Any(char.IsDigit) || firstName.Any(char.IsDigit) || middleName.Any(char.IsDigit))
            {
                error = "Поля с данными вашего имени не должны содержать цифры";
            }

            if ((string.IsNullOrEmpty(lastName)) || (string.IsNullOrEmpty(firstName)) || (string.IsNullOrEmpty(middleName)) || (string.IsNullOrEmpty(iin)))
            {
                error = "Все данные должны быть заполнены";
            }

            if (!decimal.TryParse(iin, out _))
            {
                error = "ИИН должен состоять только из цифр с 0-9";
            }

            if (iin.Length != 12)
            {
                error = "ИИН должен содержать ровно 12 символов";
            }

            var patient = new Patient(id, lastName, firstName, middleName, iin);

            return (patient, error);
        }
    }
}
