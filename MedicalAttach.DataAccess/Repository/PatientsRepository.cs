using MedicalAttach.Core.Models;
using MedicalAttach.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MedicalAttach.DataAccess.Repository.PatientsRepository;

namespace MedicalAttach.DataAccess.Repository
{
    public class PatientsRepository
    {
        public class PatientRepository : IPatientRepository
        {
            private readonly MedicalAttachDbContext _context;

            public PatientRepository(MedicalAttachDbContext context)
            {
                _context = context;
            }

            public async Task<List<Patient>> GetPatients()
            {
                var patientEntities = await _context.Patients.AsNoTracking().ToListAsync();

                var patients = patientEntities
                    .Select(p => new Patient(p.Id, p.LastName, p.FirstName, p.MiddleName, p.IIN, p.MedicalOrganizationId)
                    {
                        MedicalOrganization = p.MedicalOrganization,
                        AttachmentRequests = p.AttachmentRequests
                    }).ToList();

                return patients;
            }

            public async Task<Guid> Create(Patient patient)
            {
                var patientEntity = new PatientEntity(patient.Id, patient.LastName, patient.FirstName, patient.MiddleName, patient.IIN, patient.MedicalOrganizationId);

                await _context.Patients.AddAsync(patientEntity); // Ошибка преобразования из сущности в модель
                await _context.SaveChangesAsync();

                return patientEntity.Id;
            }

            public async Task<Guid> Update(Guid id, string lastName, string firstName, string middleName, string iin, Guid medicalOrganizationId)
            {
                await _context.Patients
                    .Where(p => p.Id == id)
                    .ExecuteUpdateAsync(s => s
                        .SetProperty(p => p.LastName, lastName)
                        .SetProperty(p => p.FirstName, firstName)
                        .SetProperty(p => p.MiddleName, middleName)
                        .SetProperty(p => p.IIN, iin)
                        .SetProperty(p => p.MedicalOrganizationId, medicalOrganizationId)
                    );

                return id;
            }

            public async Task<Guid> Delete(Guid id)
            {
                await _context.Patients
                    .Where(p => p.Id == id)
                    .ExecuteDeleteAsync();

                return id;
            }
        }
    }
}
