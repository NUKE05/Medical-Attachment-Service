using MedicalAttach.Core.Models;

namespace MedicalAttachment.Application.Services
{
    public interface IMedicalOrganizationsService
    {
        Task<List<MedicalOrganization>> GetAllMedicalOrganizations();
        Task<Guid> CreateMedicalOrganization(MedicalOrganization medicalOrganization);
        Task<Guid> UpdateMedicalOrganization(Guid id, string name);
        Task<Guid> DeleteMedicalOrganization(Guid id);
    }
}