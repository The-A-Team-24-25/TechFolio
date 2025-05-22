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
    public class SanctionsController : ControllerBase
    {
        private readonly MyProfileDbContext _context;

        public SanctionsController(MyProfileDbContext context)
        {
            _context = context;
        }

        // POST: api/sanctions
        [HttpPost]
        public async Task<ActionResult<SanctionDto>> AddSanction(SanctionDto sanctionDto)
        {
            var sanction = new Sanction
            {
                StudentId = sanctionDto.StudentId,
                Type = sanctionDto.Type,
                Date = sanctionDto.Date,
                Comment = sanctionDto.Comment
            };

            _context.Sanctions.Add(sanction);
            await _context.SaveChangesAsync();

            sanctionDto.Id = sanction.Id;
            return CreatedAtAction(nameof(GetSanction), new { id = sanction.Id }, sanctionDto);
        }

        // GET: api/sanctions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanctionDto>>> GetSanctions()
        {
            var sanctions = await _context.Sanctions
                .Select(s => new SanctionDto
                {
                    Id = s.Id,
                    StudentId = s.StudentId,
                    Type = s.Type,
                    Date = s.Date,
                    Comment = s.Comment
                })
                .ToListAsync();

            return Ok(sanctions);
        }

        // GET: api/sanctions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SanctionDto>> GetSanction(int id)
        {
            var sanction = await _context.Sanctions.FindAsync(id);
            if (sanction == null)
            {
                return NotFound();
            }

            return Ok(new SanctionDto
            {
                Id = sanction.Id,
                StudentId = sanction.StudentId,
                Type = sanction.Type,
                Date = sanction.Date,
                Comment = sanction.Comment
            });
        }

        // PUT: api/sanctions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSanction(int id, SanctionDto sanctionDto)
        {
            if (id != sanctionDto.Id)
            {
                return BadRequest();
            }

            var sanction = await _context.Sanctions.FindAsync(id);
            if (sanction == null)
            {
                return NotFound();
            }

            sanction.Type = sanctionDto.Type;
            sanction.Date = sanctionDto.Date;
            sanction.Comment = sanctionDto.Comment;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/sanctions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSanction(int id)
        {
            var sanction = await _context.Sanctions.FindAsync(id);
            if (sanction == null)
            {
                return NotFound();
            }

            _context.Sanctions.Remove(sanction);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
