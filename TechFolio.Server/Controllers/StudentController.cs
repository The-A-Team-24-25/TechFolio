using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechFolio.Server.Data;
using TechFolio.Server.DTO;
using TechFolio.Server.Models;

namespace TechFolio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly MyProfileDbContext _context;

        public StudentsController(MyProfileDbContext context)
        {
            _context = context;
        }

        // GET: api/students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var students = await _context.Students
                .Select(s => new StudentDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Class = s.Class,
                    ProfilePictureUrl = s.ProfilePictureUrl
                })
                .ToListAsync();

            return Ok(students);
        }

        // GET: api/students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Class = student.Class,
                ProfilePictureUrl = student.ProfilePictureUrl
            });
        }

        // POST: api/students
        [HttpPost]
        public async Task<ActionResult<StudentDto>> CreateStudent(StudentDto studentDto)
        {
            var student = new Student
            {
                Name = studentDto.Name,
                Class = studentDto.Class,
                ProfilePictureUrl = studentDto.ProfilePictureUrl
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            studentDto.Id = student.Id;

            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, studentDto);
        }

        // PUT: api/students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentDto studentDto)
        {
            if (id != studentDto.Id)
            {
                return BadRequest();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            student.Name = studentDto.Name;
            student.Class = studentDto.Class;
            student.ProfilePictureUrl = studentDto.ProfilePictureUrl;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
