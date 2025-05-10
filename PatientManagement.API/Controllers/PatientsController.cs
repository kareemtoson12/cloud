using Microsoft.AspNetCore.Mvc;
using HealthcareManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            // TODO: Implement actual data access
            return Ok(new List<Patient>());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(Guid id)
        {
            // TODO: Implement actual data access
            return Ok(new Patient { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Patient>> CreatePatient(Patient patient)
        {
            // TODO: Implement actual data access
            patient.Id = Guid.NewGuid();
            patient.RegistrationDate = DateTime.UtcNow;
            return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(Guid id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            // TODO: Implement actual data access
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            // TODO: Implement actual data access
            return NoContent();
        }
    }
} 