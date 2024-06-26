using MedicalAttach.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAttach.Core.Abstractions
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAllPatients();
        Task<Guid> CreatePatient(Patient patient);
        Task<Guid> UpdatePatient(Guid id, string lastName, string firstName, string middleName, string iin);
        Task <Guid> DeletePatient(Guid id);
        // dTask<List<Patient>> SearchPatients(string lastName, string firstName, string middleName, string iin);
    }
}
