using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TechFolio.Data.Models;
using TechFolio.Server.Data;
using Microsoft.EntityFrameworkCore;


namespace TechFolio.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoalsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GoalsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoalsDto>>> GetGoals()
        {
            return await _context.Goals
                .Select(g => new GoalsDto
                {
                    Id = g.Id,
                    Title = g.Title,
                    Description = g.Description,
                    Type = g.Type,
                    IsApproved = g.IsApproved
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GoalsDto>> GetGoal(int id)
        {
            var goal = await _context.Goals.FindAsync(id);
            if (goal == null) return NotFound();

            return new GoalsDto
            {
                Id = goal.Id,
                Title = goal.Title,
                Description = goal.Description,
                Type = goal.Type,
                IsApproved = goal.IsApproved
            };
        }

        [HttpPost]
        public async Task<ActionResult<GoalsDto>> CreateGoal([FromBody] GoalsDto dto)
        {
            var goal = new Goal
            {
                Title = dto.Title,
                Description = dto.Description,
                Type = dto.Type,
                IsApproved = dto.IsApproved
            };

            _context.Goals.Add(goal);
            await _context.SaveChangesAsync();

            dto.Id = goal.Id;
            return CreatedAtAction(nameof(GetGoal), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGoal(int id, [FromBody] GoalsDto dto)
        {
            var goal = await _context.Goals.FindAsync(id);
            if (goal == null) return NotFound();

            goal.Title = dto.Title;
            goal.Description = dto.Description;
            goal.Type = dto.Type;
            goal.IsApproved = dto.IsApproved;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoal(int id)
        {
            var goal = await _context.Goals.FindAsync(id);
            if (goal == null) return NotFound();

            _context.Goals.Remove(goal);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}

