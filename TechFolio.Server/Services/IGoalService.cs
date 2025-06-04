using TechFolio.Data.Models;

public interface IGoalService
{
    Task<IEnumerable<GoalsDto>> GetAllGoalsAsync();
    Task<GoalsDto?> GetGoalByIdAsync(int id);
    Task<GoalsDto> CreateGoalAsync(GoalsDto dto);
    Task<bool> UpdateGoalAsync(int id, GoalsDto dto);
    Task<bool> DeleteGoalAsync(int id);
}
