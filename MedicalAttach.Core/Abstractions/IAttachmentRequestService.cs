using MedicalAttach.Core.Models;

namespace MedicalAttachment.Application.Services
{
    public interface IAttachmentRequestService
    {
        Task<List<AttachmentRequest>> GetAllAttachmentRequests();
        Task<Guid> CreateAttachmentRequest(AttachmentRequest attachmentRequest);
        Task<Guid> UpdateAttachmentRequest(Guid id, DateTime creationDate, DateTime processingDate, Guid PatientId, Guid MedicalOrganizationId, string status);
        Task<Guid> DeleteAttachmentRequest(Guid id);
    }
}