using MedicalAttach.Core.Abstractions;
using MedicalAttach.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAttachment.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _userRepository;
        private readonly IMedicalOrganizationsRepository _medicalOrganizationsRepository;

        public UserService(IUsersRepository userRepository, IMedicalOrganizationsRepository medicalOrganizationsRepository)
        {
            _userRepository = userRepository;
            _medicalOrganizationsRepository = medicalOrganizationsRepository;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task<Guid> CreateUser(User user)
        {
            return await _userRepository.Create(user);
        }

        public async Task<Guid> UpdateUser(Guid id, string login, string password, bool isAdmin, Guid medicalOrganizationId)
        {
            return await _userRepository.Update(id, login, password, isAdmin, medicalOrganizationId);
        }

        public async Task<Guid> DeleteUser(Guid id)
        {
            return await _userRepository.Delete(id);
        }
    }
}
