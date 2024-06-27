using MedicalAttach.Core.Abstractions;
using MedicalAttach.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAttachment.Application.Services
{
    public class MedicalOrganizationService : IMedicalOrganizationsService
    {
        private readonly IMedicalOrganizationsRepository _medicalOrganizationRepository;

        public MedicalOrganizationService(IMedicalOrganizationsRepository medicalOrganizationRepository)
        {
            _medicalOrganizationRepository = medicalOrganizationRepository;
        }

        public async Task<List<MedicalOrganization>> GetAllMedicalOrganizations()
        {
            return await _medicalOrganizationRepository.GetMedicalOrganizations();
        }

        public async Task<Guid> CreateMedicalOrganization(MedicalOrganization medicalOrganization)
        {
            return await _medicalOrganizationRepository.Create(medicalOrganization);
        }

        public async Task<Boolean> GetMedicalOrganizationById(Guid id)
        {
            var containsId = _medicalOrganizationRepository.ContainsMedId(id);

            return await containsId;
        }

        public async Task<Guid> UpdateMedicalOrganization(Guid id, string name)
        {
            return await (_medicalOrganizationRepository.Update(id, name)); 
        }

        public async Task<Guid> DeleteMedicalOrganization(Guid id)
        {
            return await _medicalOrganizationRepository.Delete(id);
        }
    }
}
