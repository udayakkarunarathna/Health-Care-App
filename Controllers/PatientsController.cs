namespace HealthcareAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using global::HealthcareAPI.Data;
    using global::HealthcareAPI.Models;

    namespace HealthcareAPI.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class PatientsController : ControllerBase
        {
            private readonly HealthcareContext _context;

            public PatientsController(HealthcareContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
            {
                return await _context.Patients.ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Patient>> GetPatient(int id)
            {
                var patient = await _context.Patients.FindAsync(id);
                if (patient == null) return NotFound();
                return patient;
            }

            [HttpPost]
            public async Task<ActionResult<Patient>> PostPatient(Patient patient)
            {
                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetPatient), new { id = patient.PatientId }, patient);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutPatient(int id, Patient patient)
            {
                if (id != patient.PatientId) return BadRequest();
                _context.Entry(patient).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeletePatient(int id)
            {
                var patient = await _context.Patients.FindAsync(id);
                if (patient == null) return NotFound();
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
    }
}
