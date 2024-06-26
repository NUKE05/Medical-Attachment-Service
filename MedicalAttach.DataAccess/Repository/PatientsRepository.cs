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
    public class PatientsRepository : IPatientsRepository 
    {
        private readonly MedicalAttachDbContext _context;

        public PatientsRepository(MedicalAttachDbContext context)
        {
            _context = context;
        }

        public async Task<List<Patient>> GetPatients()
        {
            var patientEntities = await _context.Patients.AsNoTracking().ToListAsync();

            var patients = patientEntities
                .Select(p => new Patient(p.Id, p.LastName, p.FirstName, p.MiddleName, p.IIN))
                .ToList();

            return patients;
        }

        public async Task<Patient> GetPatientById(Guid id)
        {
            var patientEntity = await _context.Patients.FindAsync(id);
            if (patientEntity == null) return null;
            return new Patient(patientEntity.Id, patientEntity.LastName, patientEntity.FirstName, patientEntity.MiddleName, patientEntity.IIN);
        }

        public async Task<Guid> Create(Patient patient)
        {
            var patientEntity = new PatientEntity
            {
                Id = patient.Id,
                LastName = patient.LastName,
                FirstName = patient.FirstName,
                MiddleName = patient.MiddleName,
                IIN = patient.IIN
            };

            await _context.Patients.AddAsync(patientEntity);
            await _context.SaveChangesAsync();

            return patientEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string lastName, string firstName, string middleName, string iin)
        {
            await _context.Patients
                .Where(p => p.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(p => p.LastName, lastName)
                    .SetProperty(p => p.FirstName, firstName)
                    .SetProperty(p => p.MiddleName, middleName)
                    .SetProperty(p => p.IIN, iin)
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

        /*public async Task<List<Patient>> SearchPatients(string lastName, string firstName, string middleName, string iin)
        {
            var query = _context.Patients.AsQueryable();

            if (!string.IsNullOrEmpty(lastName))
                query = query.Where(p => p.LastName.Contains(lastName, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(firstName))
                query = query.Where(p => p.FirstName.Contains(firstName, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(middleName))
                query = query.Where(p => p.MiddleName.Contains(middleName, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(iin))
                query = query.Where(p => p.IIN.Contains(iin, StringComparison.OrdinalIgnoreCase));

            var patientEntities = await query.AsNoTracking().ToListAsync();
            return patientEntities.Select(p => new Patient(p.Id, p.LastName, p.FirstName, p.MiddleName, p.IIN)).ToList();
        }*/

        /*Task IPatientsRepository.Delete(Guid id)
        {
            throw new NotImplementedException();
        }*/
    }
}
