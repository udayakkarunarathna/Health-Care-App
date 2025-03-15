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
        public class DoctorsController : ControllerBase
        {
            private readonly HealthcareContext _context;

            public DoctorsController(HealthcareContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
            {
                return await _context.Doctors.ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Doctor>> GetDoctor(int id)
            {
                var doctor = await _context.Doctors.FindAsync(id);
                if (doctor == null) return NotFound();
                return doctor;
            }

            [HttpPost]
            public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
            {
                _context.Doctors.Add(doctor);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetDoctor), new { id = doctor.DoctorId }, doctor);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutDoctor(int id, Doctor doctor)
            {
                if (id != doctor.DoctorId) return BadRequest();
                _context.Entry(doctor).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteDoctor(int id)
            {
                var doctor = await _context.Doctors.FindAsync(id);
                if (doctor == null) return NotFound();
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
    }
}
