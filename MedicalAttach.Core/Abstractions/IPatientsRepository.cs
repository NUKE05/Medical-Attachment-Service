using MedicalAttach.Core.Models;

namespace MedicalAttach.DataAccess.Repository
{
    public interface IPatientsRepository
    {
        Task<List<Patient>> GetPatients();
        Task<Patient> GetPatientById(Guid id);
        Task<Guid> Create(Patient patient);
        Task<Guid> Update(Guid id, string lastName, string firstName, string middleName, string iin);
        Task Delete(Guid id);
        Task<List<Patient>> SearchPatients(string lastName, string firstName, string middleName, string iin);
    }
}