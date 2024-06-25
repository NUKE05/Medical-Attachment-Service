using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalAttach.Core.Abstractions;
using MedicalAttach.Core.Models;
using MedicalAttach.DataAccess.Repository;

namespace MedicalAttachment.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientsRepository _patientRepository;
        private readonly IAttachmentRequestsRepository _attachmentRequestRepository;
        private readonly IUsersRepository _userRepository;

        public PatientService(IPatientsRepository patientRepository, IAttachmentRequestsRepository attachmentRequestRepository, IUsersRepository userRepository)
        {
            _patientRepository = patientRepository;
            _attachmentRequestRepository = attachmentRequestRepository;
            _userRepository = userRepository;
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            return await _patientRepository.GetPatients();
        }

        public async Task<Guid> CreatePatient(Patient patient)
        {
            return await _patientRepository.Create(patient);
        }

        public async Task<Guid> UpdatePatient(Guid id, string lastName, string firstName, string middleName, string iin)
        {
            return await (_patientRepository.Update(id, lastName, firstName, middleName, iin));
        }

        public async Task DeletePatient(Guid id) { 
            await _patientRepository.Delete(id);
        }


        /*public async Task<List<Patient>> SearchPatients(string lastName, string firstName, string middleName, string iin)
        {
            var patients = await _patientRepository.SearchPatients(lastName, firstName, middleName, iin);
            var attachmentRequests = await _attachmentRequestRepository.GetAttachmentRequests();

            return patients.Where(p =>
                    !attachmentRequests.Any(ar => ar.PatientId == p.Id)
                ).ToList();*/

        // Change code here, so it can seach patients by their names using crud operations

        // The structure where the project doesn't implement own CRUD operations
        /*return patients.Where(p =>
                (string.IsNullOrEmpty(lastName) || p.LastName.Contains(lastName, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(firstName) || p.FirstName.Contains(firstName, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(middleName) || p.MiddleName.Contains(middleName, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(iin) || p.IIN.Contains(iin, StringComparison.OrdinalIgnoreCase)) 
            ).ToList();*/
    }

        /*Task IPatientService.DeletePatient(Guid id)
        {
            throw new NotImplementedException();
        }*/

        /*public async Task CreateAttachmentRequest(Guid patientId, Guid organizationId, Guid userId)
        {
            var user = await _userRepository.GetUsers();
            var patients = await _patientRepository.GetPatients();
            var patient = patients.Where(p => p.Id == patientId).FirstOrDefault();
            var currentUser = user.FirstOrDefault(u => u.Id == userId);

            if (currentUser != null)
            {
                var isUserAdmin = currentUser.IsAdmin;
                var userOrganization = currentUser.MedicalOrganization;

                if (isUserAdmin || userOrganization.Id == organizationId)
                {
                    var attachmentRequest = new AttachmentRequest(Guid.NewGuid(), DateTime.Now, DateTime.Today, patient, "Pending");
                    await _attachmentRequestRepository.Create(attachmentRequest);
                }
            }
        }*/

        /*public async Task<List<Patient>> GetAttachedPatients(Guid? organizationId = null, Guid? userId = null)
        {
            var patients = await _patientRepository.GetPatients();
            if (organizationId.HasValue)
            {
                var user = await _userRepository.GetUsers();
                var currentUser = user.FirstOrDefault(u => u.Id == userId);

                if (currentUser != null)
                {
                    var isUserAdmin = currentUser.IsAdmin;
                    var userOrganizationId = currentUser.MedicalOrganizationId;

                    if (!isUserAdmin)
                    {
                        organizationId = userOrganizationId;
                    }
                }
            }
            return patients;
        }*/
}
