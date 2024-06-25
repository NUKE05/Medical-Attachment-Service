using MedicalAttach.Core.Models;
using MedicalAttach.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MedicalAttach.DataAccess.Repository.UsersRepository;

namespace MedicalAttach.DataAccess.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly MedicalAttachDbContext _context;

        public UsersRepository(MedicalAttachDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            var userEntities = await _context.Users.AsNoTracking().ToListAsync();

            var users = userEntities
                .Select(u => new User(u.Id, u.Login, u.Password, u.IsAdmin, u.MedicalOrganizationID))
                .ToList();

            return users;
        }

        public async Task<Guid> Create(User user)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                IsAdmin = user.IsAdmin,
                MedicalOrganizationID = user.MedicalOrganizationId
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            return userEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string login, string password, bool isAdmin, Guid medicalOrganizationId)
        {
            await _context.Users
                .Where(u => u.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(u => u.Login, login)
                    .SetProperty(u => u.Password, password)
                    .SetProperty(u => u.IsAdmin, isAdmin)
                    .SetProperty(u => u.MedicalOrganizationID, medicalOrganizationId)
                );

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Users
                .Where(u => u.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
