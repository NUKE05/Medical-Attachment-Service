using MedicalAttach.Core.Models;

namespace MedicalAttachment.Application.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<Guid> CreateUser(User user);
        Task<Guid> UpdateUser(Guid id, string login,  string password, bool isAdmin, Guid medicalOrganizationId);
        Task<Guid> DeleteUser(Guid id);

    }
}