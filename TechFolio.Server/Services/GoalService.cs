using Microsoft.EntityFrameworkCore;
using TechFolio.Data.Models;
using TechFolio.Server.Data;

public class GoalService : IGoalService
{
    private readonly AppDbContext _context;

    public GoalService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GoalsDto>> GetAllGoalsAsync()
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

    public async Task<GoalsDto?> GetGoalByIdAsync(int id)
    {
        var goal = await _context.Goals.FindAsync(id);
        if (goal == null) return null;

        return new GoalsDto
        {
            Id = goal.Id,
            Title = goal.Title,
            Description = goal.Description,
            Type = goal.Type,
            IsApproved = goal.IsApproved
        };
    }

    public async Task<GoalsDto> CreateGoalAsync(GoalsDto dto)
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
        return dto;
    }

    public async Task<bool> UpdateGoalAsync(int id, GoalsDto dto)
    {
        var goal = await _context.Goals.FindAsync(id);
        if (goal == null) return false;

        goal.Title = dto.Title;
        goal.Description = dto.Description;
        goal.Type = dto.Type;
        goal.IsApproved = dto.IsApproved;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteGoalAsync(int id)
    {
        var goal = await _context.Goals.FindAsync(id);
        if (goal == null) return false;

        _context.Goals.Remove(goal);
        await _context.SaveChangesAsync();
        return true;
    }
}
