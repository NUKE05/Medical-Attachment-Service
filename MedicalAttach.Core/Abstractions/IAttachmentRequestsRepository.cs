using MedicalAttach.Core.Models;

namespace MedicalAttach.DataAccess.Repository
{
    public interface IAttachmentRequestsRepository
    {
        Task<List<AttachmentRequest>> GetAttachmentRequests();
        Task<Guid> Create(AttachmentRequest attachmentRequest);
        Task<Guid> Update(Guid id, DateTime creationDate, DateTime processingDate, string status, Patient patient);
        Task<Guid> Delete(Guid id);
    }
}