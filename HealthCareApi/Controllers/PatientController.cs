using HealthCare.Api.Infrastructure.Validators;
using HealthCare.Api.ViewModels;
using HealthCare.Core.Services;
using HealthCare.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HealthCare.Controllers
{
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly ILogger<PatientController> _logger;

        public PatientController(IPatientService patientService, ILogger<PatientController> logger)
        {
            _patientService = patientService;
            _logger = logger;   
        }

        [Route("api/[Controller]")]
        [HttpPost]
        public async Task<IActionResult> AddPatient(PatientAddModel patientModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!ValidateBirthDate(patientModel))
            {
                ModelState.AddModelError("BirthDate", "Birth date cannot be empty");
                return BadRequest(ModelState);
            }

            if (!ValidateFamily(patientModel))
            {
                ModelState.AddModelError("Family", "Family cannot be empty");
                return BadRequest(ModelState);
            }

            var patientId = Guid.Empty;
            try
            {
                patientId = await _patientService.AddPatient(patientModel.ToEntity());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something goes wrong: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok(patientId);
        }

        [HttpGet]
        [Route("api/[Controller]/{id:guid}")]
        public async Task<IActionResult> GetPatient(Guid id)
        {
            try
            {
                var result = await _patientService.GetById(id);
                if (result == null)
                    return NotFound();

                return Ok(new PatientAddModel(result));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something goes wrong: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("api/[Controller]")]
        public async Task<IActionResult> UpdatePatient(PatientEditModel patientModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _patientService.UpdatePatient(patientModel.ToEntity());
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something goes wrong: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/[Controller]/{id:guid}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            try
            {
                await _patientService.RemovePatient(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something goes wrong: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/[Controller]/search")]
        public async Task<IActionResult> PatientSearch([FromQuery][DateSearch(ErrorMessage = "Input date(s) in incorrect format")] string[] date)
        {
            try
            {
                var result = await _patientService.PatientSearch(date);

                return Ok(result.Select(p => new PatientEditModel(p)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something goes wrong: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/[Controller]/GetAll")]
        public async Task<IActionResult> GetAllPatients()
        {
            try
            {
                var result = await _patientService.GetAllPatients();

                return Ok(result.Select(p => new PatientEditModel(p)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something goes wrong: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        private bool ValidateBirthDate(PatientAddModel model)
        {
            return !string.IsNullOrWhiteSpace(model.PatientBirthDate);
        }

        private bool ValidateFamily(PatientAddModel model)
        {
            return !string.IsNullOrWhiteSpace(model.Name.Family);
        }
    }
}
