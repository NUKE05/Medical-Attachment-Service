using Medical_Attachment_Service.Contracts;
using MedicalAttach.Core.Abstractions;
using MedicalAttach.Core.Models;
using MedicalAttachment.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Attachment_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AttachmentRequestsController : ControllerBase
    {
        private readonly IAttachmentRequestService _attachmentRequestService;

        public AttachmentRequestsController(IAttachmentRequestService attachmentRequestService)
        {
            _attachmentRequestService = attachmentRequestService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AttachmentRequest_Responce>>> GetAttachmentRequests()
        {
            var attachmentRequests = await _attachmentRequestService.GetAllAttachmentRequests();

            var response = attachmentRequests.Select(ar => new AttachmentRequest_Responce(
                ar.Id, ar.CreationDate, ar.ProcessingDate, ar.PatientId, ar.MedicalOrganizationId, ar.Status));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAttachmentRequest([FromBody] AttachmentRequest_Request request)
        {
            var attachmentRequest = new AttachmentRequest(
                Guid.NewGuid(),
                request.CreationDate,
                request.ProcessingDate,
                request.PatientId,
                request.MedicalOrganizationId,
                request.Status);

            var existingRequests = await _attachmentRequestService.GetAllAttachmentRequests();

            if (existingRequests.Any(ar => ar.PatientId == request.PatientId && ar.CreationDate == request.CreationDate))
            {
                return BadRequest("Заявка с данным пациентом и датой создания уже существует");
            }

            var attachmentRequestId = await _attachmentRequestService.CreateAttachmentRequest(attachmentRequest);

            return Ok(attachmentRequestId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateAttachmentRequest(Guid id, [FromBody] AttachmentRequest_Request request)
        {
            var updatedAttachmentRequest = await _attachmentRequestService.UpdateAttachmentRequest(
                id, request.CreationDate, request.ProcessingDate, request.PatientId, request.MedicalOrganizationId, request.Status);

            return Ok(updatedAttachmentRequest);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteAttachmentRequest(Guid id)
        {
            return Ok(await _attachmentRequestService.DeleteAttachmentRequest(id));
        }
    }
}
