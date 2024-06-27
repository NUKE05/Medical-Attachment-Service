using MedicalAttach.Core.Abstractions;
using MedicalAttach.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAttachment.Application.Services
{
    public class AttachmentRequestService : IAttachmentRequestService
    {
        private readonly IAttachmentRequestsRepository _attachmentRepository;

        public AttachmentRequestService(IAttachmentRequestsRepository attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }

        public async Task<List<AttachmentRequest>> GetAllAttachmentRequests()
        {
            return await _attachmentRepository.GetAttachmentRequests();
        }

        public async Task<Guid> CreateAttachmentRequest(AttachmentRequest attachmentRequest)
        {
            return await _attachmentRepository.Create(attachmentRequest);
        }

        public async Task<Guid> UpdateAttachmentRequest(Guid id, DateTime creationDate, DateTime processingDate, Guid PatientId, Guid MedicalOrganizationId, string status)
        {
            return await _attachmentRepository.Update(id, creationDate, processingDate, PatientId, MedicalOrganizationId, status);
        } 

        public async Task<Guid> DeleteAttachmentRequest(Guid id)
        {
            return await _attachmentRepository.Delete(id);
        }
    }
}