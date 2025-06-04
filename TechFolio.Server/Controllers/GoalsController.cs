using Microsoft.AspNetCore.Mvc;
using TechFolio.Data.Models;

namespace TechFolio.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoalsController : ControllerBase
    {
        private readonly IGoalService _goalService;

        public GoalsController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoalsDto>>> GetGoals()
        {
            var goals = await _goalService.GetAllGoalsAsync();
            return Ok(goals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GoalsDto>> GetGoal(int id)
        {
            var goal = await _goalService.GetGoalByIdAsync(id);
            if (goal == null) return NotFound();

            return Ok(goal);
        }

        [HttpPost]
        public async Task<ActionResult<GoalsDto>> CreateGoal([FromBody] GoalsDto dto)
        {
            var created = await _goalService.CreateGoalAsync(dto);
            return CreatedAtAction(nameof(GetGoal), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGoal(int id, [FromBody] GoalsDto dto)
        {
            var success = await _goalService.UpdateGoalAsync(id, dto);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoal(int id)
        {
            var success = await _goalService.DeleteGoalAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
