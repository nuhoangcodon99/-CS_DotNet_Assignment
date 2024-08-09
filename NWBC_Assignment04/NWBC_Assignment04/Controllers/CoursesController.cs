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
    // [Route("api/[controller]")]
    // [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly MyDBContext _context;
        // private readonly ILogger _logger;
        public CoursesController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/Management
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        // GET: api/Management/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _context.Courses.Include(c => c.Students).FirstOrDefaultAsync(e => e.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // PUT: api/Management/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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

        // POST: api/Management
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            _context.Courses.Add(course);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CourseExists(course.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        // DELETE: api/Management/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }

        [HttpPost("student/{idCourse}/{idStudent}")]
        public async Task<ActionResult<Course>> AddStudent(int idStudent,int idCourse)
        {
            Student? student = await _context.Students.FindAsync(idStudent);
            Course? course = await _context.Courses.Include(c => c.Students).FirstOrDefaultAsync(e => e.Id == idCourse);
            if (course == null || student == null )
            {
                return BadRequest();
            }

            course.Students.Add(student);
            _context.Entry(course).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // _logger.LogError(ex, "An error occurred while updating the database.");

                // Trả về phản hồi cụ thể cho người dùng
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the database. Please try again later.");
            }

            return NoContent();
        }
    }
}
