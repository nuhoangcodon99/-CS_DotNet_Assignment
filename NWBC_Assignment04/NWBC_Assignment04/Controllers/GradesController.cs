using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NWBC_Assignment04.DBContext;
using NWBC_Assignment04.Entities;

namespace NWBC_Assignment04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly MyDBContext _context;

        public GradesController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/Grades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grade>>> GetAllGrade()
        {
            return await _context.Grade.ToListAsync();
        }

        // GET: api/Grades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grade>> GetGrade(int id)
        {
            var grade = await _context.Grade.FindAsync(id);

            if (grade == null)
            {
                return NotFound();
            }

            return grade;
        }

        // PUT: api/Grades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGrade(int id, Grade grade)
        {
            if (id != grade.Id)
            {
                return BadRequest();
            }

            _context.Entry(grade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Grades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Grade>> PostGrade(Grade grade)
        {
            _context.Grade.Add(grade);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GradeExists(grade.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGrade", new { id = grade.Id }, grade);
        }

        // DELETE: api/Grades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            var grade = await _context.Grade.FindAsync(id);
            if (grade == null)
            {
                return NotFound();
            }

            _context.Grade.Remove(grade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GradeExists(int id)
        {
            return _context.Grade.Any(e => e.Id == id);
        }

        [HttpGet("students/{id}")]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudent(int id)
        {
            var grade = await _context.Grade.Include(s => s.Students).FirstOrDefaultAsync(e => e.Id == id);
            if (grade == null)
            {
                return NotFound();
            }
            

            return Ok(grade.Students);

        }
    }
}
