using Medical_Attachment_Service.Contracts;
using MedicalAttach.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Attachment_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpGet]
        public async Task<ActionResult<List<PatientResponce>>> GetPatients()
        {
            var patients = await _patientService.GetAllPatients();

            var responce = patients.Select(p => new PatientResponce(p.Id, p.LastName, p.FirstName, p.MiddleName, p.IIN));

            return Ok(responce);

        }

    }
}
