using Medical_Attachment_Service.Contracts;
using MedicalAttach.Core.Abstractions;
using MedicalAttach.Core.Models;
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
        [HttpPost]
        public async Task<ActionResult<Guid>> CreatePatient([FromBody] PatientRequest request)
        {
            var (patient, error) = Patient.Create(
                Guid.NewGuid(),
                request.LastName,
                request.FirstName,
                request.MiddleName,
                request.Iin);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var patientId = await _patientService.CreatePatient(patient);

            return Ok(patientId);
        }
    }
}
