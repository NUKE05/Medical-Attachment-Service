using MedicalAttach.Core.Models;

namespace MedicalAttach.Core.Abstractions
{
    public interface IUsersRepository
    {
        Task<List<User>> GetUsers();
        Task<Guid> Create(User user);
        Task<Guid> Update(Guid id, string login, string password, bool isAdmin, Guid medicalOrganizationId);
        Task<Guid> Delete(Guid id);
    }
}