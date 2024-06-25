using MedicalAttach.Core.Models;
using MedicalAttach.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MedicalAttach.DataAccess.Repository.MedicalOrganizationsRepository;

namespace MedicalAttach.DataAccess.Repository
{
    public class MedicalOrganizationsRepository : IMedicalOrganizationsRepository
    {
        private readonly MedicalAttachDbContext _context;

        public MedicalOrganizationsRepository(MedicalAttachDbContext context)
        {
            _context = context;
        }

        public async Task<List<MedicalOrganization>> GetMedicalOrganizations()
        {
            var medicalOrganizationEntities = await _context.MedicalOrganizations.AsNoTracking().ToListAsync();

            var medicalOrganizations = medicalOrganizationEntities
                .Select(m => new MedicalOrganization(m.Id, m.Name))
                .ToList();

            return medicalOrganizations;
        }

        public async Task<Guid> Create(MedicalOrganization medicalOrganization)
        {
            var medicalOrganizationEntity = new MedicalOrganizationEntity
            {
                Id = medicalOrganization.Id,
                Name = medicalOrganization.Name
            };

            await _context.MedicalOrganizations.AddAsync(medicalOrganizationEntity);
            await _context.SaveChangesAsync();

            return medicalOrganizationEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name)
        {
            await _context.MedicalOrganizations
                .Where(m => m.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(m => m.Name, name)
                );

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.MedicalOrganizations
                .Where(m => m.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
