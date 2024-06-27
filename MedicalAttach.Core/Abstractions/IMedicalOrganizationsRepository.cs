using MedicalAttach.Core.Models;

namespace MedicalAttach.Core.Abstractions
{
    public interface IMedicalOrganizationsRepository
    {
        Task<List<MedicalOrganization>> GetMedicalOrganizations();
        Task<Guid> Create(MedicalOrganization medicalOrganization);
        Task<Guid> Update(Guid id, string name);
        Task<Guid> Delete(Guid id);
        Task <Boolean> ContainsMedId(Guid id);
    }
}