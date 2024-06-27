using Medical_Attachment_Service.Contracts;
using MedicalAttach.Core.Abstractions;
using MedicalAttach.Core.Models;
using MedicalAttachment.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Attachment_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicalOrganizationsController : ControllerBase    
    {
        private readonly IMedicalOrganizationsService _medicalOrganizationsService;

        public MedicalOrganizationsController(IMedicalOrganizationsService medicalOrganizationsService)
        {
            _medicalOrganizationsService = medicalOrganizationsService;
        }
        [HttpGet]
        public async Task<ActionResult<List<MedicalOrganizationResponce>>> GetMedicalOrganizations()
        {
            var medicalOrganizations = await _medicalOrganizationsService.GetAllMedicalOrganizations();

            var responce = medicalOrganizations.Select(mo => new MedicalOrganizationResponce(mo.Id, mo.Name));

            return Ok(responce);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateMedicalOrganization([FromBody] MedicalOrganizationRequest request)
        {
            var (medicalOrganization, error) = MedicalOrganization.Create(
                Guid.NewGuid(), 
                request.Name);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var medicalOrganizationId = await _medicalOrganizationsService.CreateMedicalOrganization(medicalOrganization);

            return Ok(medicalOrganizationId);

        }

        [HttpPut("{id:guid}")]    
        public async Task<ActionResult<Guid>> UpdateMedicalOrganization(Guid id, [FromBody]MedicalOrganizationRequest request)
        {
            var MedicalOrganization = await _medicalOrganizationsService.UpdateMedicalOrganization(id, request.Name);

            return Ok(MedicalOrganization);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteMedicalOrganization(Guid id)
        {
            return Ok(await _medicalOrganizationsService.DeleteMedicalOrganization(id));
        }

    }
}
