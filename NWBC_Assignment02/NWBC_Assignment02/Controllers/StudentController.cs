using Microsoft.AspNetCore.Mvc;
using NWBC_Assignment02.Entities;
using NWBC_Assignment02.Repositories;

namespace NWBC_Assignment02.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllStudents()
    {
        var students = StudentRepository.GetAllStudents();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public IActionResult GetStudent(int id)
    {
        var student = StudentRepository.GetStudent(id);
        if (student == null)
        {
            return NotFound();
        }

        return Ok(student);
    }

    [HttpPost]
    public IActionResult AddStudent([FromBody] Student student)
    {
        StudentRepository.AddStudent(student);
        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStudent(int id, [FromBody] Student student)
    {
        if (!StudentRepository.UpdateStudent(id, student))
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        if (!StudentRepository.DeleteStudent(id))
        {
            return NotFound();
        }

        return NoContent();
    }
}