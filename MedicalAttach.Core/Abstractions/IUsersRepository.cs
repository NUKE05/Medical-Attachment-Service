using MedicalAttach.Core.Models;

namespace MedicalAttach.DataAccess.Repository
{
    public interface IUsersRepository
    {
        Task<List<User>> GetUsers();
        Task<Guid> Create(User user);
        Task<Guid> Update(Guid id, string login, string password, bool isAdmin, MedicalOrganization medicalOrganization);
        Task<Guid> Delete(Guid id);
    }
}