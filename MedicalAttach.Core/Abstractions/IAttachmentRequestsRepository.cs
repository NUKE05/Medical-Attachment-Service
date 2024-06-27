using MedicalAttach.Core.Models;

namespace MedicalAttach.Core.Abstractions
{
    public interface IAttachmentRequestsRepository
    {
        Task<List<AttachmentRequest>> GetAttachmentRequests();
        Task<Guid> Create(AttachmentRequest attachmentRequest);
        Task<Guid> Update(Guid id, DateTime creationDate, DateTime processingDate, Guid patientId, Guid MedicalOrganizationId, string status);
        Task<Guid> Delete(Guid id);
    }
}