using MedicalAttach.Core.Models;
using MedicalAttach.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MedicalAttach.DataAccess.Repository.AttachmentRequestsRepository;

namespace MedicalAttach.DataAccess.Repository
{
    public class AttachmentRequestsRepository : IAttachmentRequestsRepository
    {
        private readonly MedicalAttachDbContext _context;

        public AttachmentRequestsRepository(MedicalAttachDbContext context)
        {
            _context = context;
        }

        public async Task<List<AttachmentRequest>> GetAttachmentRequests()
        {
            var attachmentRequestEntities = await _context.AttachmentRequests.AsNoTracking().ToListAsync();

            var attachmentRequests = attachmentRequestEntities
                .Select(ar => new AttachmentRequest(ar.Id, ar.CreationDate, ar.ProcessingDate, ar.PatientId, ar.Status))
                .ToList();

            return attachmentRequests;
        }

        public async Task<Guid> Create(AttachmentRequest attachmentRequest)
        {
            var attachmentRequestEntity = new AttachmentRequestEntity
            {
                Id = attachmentRequest.Id,
                CreationDate = attachmentRequest.CreationDate,
                ProcessingDate = attachmentRequest.ProcessingDate,
                Status = attachmentRequest.Status,
                PatientId = attachmentRequest.PatientId
            };

            await _context.AttachmentRequests.AddAsync(attachmentRequestEntity);
            await _context.SaveChangesAsync();

            return attachmentRequestEntity.Id;
        }

        public async Task<Guid> Update(Guid id, DateTime creationDate, DateTime processingDate, Guid patientId,string status)
        {
            await _context.AttachmentRequests
                .Where(ar => ar.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(ar => ar.CreationDate, creationDate)
                    .SetProperty(ar => ar.ProcessingDate, processingDate)
                    .SetProperty(ar => ar.Status, status)
                    .SetProperty(ar => ar.PatientId, patientId)
                );

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.AttachmentRequests
                .Where(ar => ar.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
