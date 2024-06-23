﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAttach.Core.Models
{
    public class User
    {
        public User(Guid id, string login, string password, bool isAdmin, Guid medicalOrganizationId)
        {
            Id = id;
            Login = login;
            Password = password;
            IsAdmin = isAdmin;
            MedicalOrganizationId = medicalOrganizationId;
        }

        public Guid Id { get; }
        public string Login { get; } = string.Empty;
        public string Password { get; } = string.Empty;
        public bool IsAdmin { get; }
        public Guid MedicalOrganizationId { get; }
        public MedicalOrganization MedicalOrganization { get; set; }

    }
}