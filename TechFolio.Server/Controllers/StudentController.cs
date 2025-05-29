// Controllers/StudentsController.cs
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
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly MyProfileDbContext _context;

        public StudentsController(MyProfileDbContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAll()
        {
            var students = await _context.Students.ToListAsync();
            var dtos = students.Select(s => new StudentDto
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                ClassName = s.ClassName
            }).ToList();

            return Ok(dtos);
        }

        // GET: api/Students/grouped-by-class
        [HttpGet("grouped-by-class")]
        public async Task<ActionResult<IEnumerable<StudentGroupDto>>> GetGroupedByClass()
        {
            var students = await _context.Students.ToListAsync();

            var groups = students
                .GroupBy(s => s.ClassName)
                .Select(g => new StudentGroupDto
                {
                    ClassName = g.Key,
                    Students = g.Select(s => new StudentDto
                    {
                        Id = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Email = s.Email,
                        ClassName = s.ClassName
                    }).ToList()
                })
                .OrderBy(g => g.ClassName)
                .ToList();

            return Ok(groups);
        }

        // POST: api/Students
        [HttpPost]
        public async Task<ActionResult<StudentDto>> Create(StudentDto input)
        {
            var student = new Student
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email,
                ClassName = input.ClassName
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            input.Id = student.Id;
            return CreatedAtAction(nameof(GetAll), new { id = student.Id }, input);
        }

        // PUT: api/Students/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentDto input)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            student.FirstName = input.FirstName;
            student.LastName = input.LastName;
            student.Email = input.Email;
            student.ClassName = input.ClassName;

            _context.Students.Update(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Students/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}