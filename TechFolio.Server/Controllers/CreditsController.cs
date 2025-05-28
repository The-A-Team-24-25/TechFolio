using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechFolio.Server.Data;


namespace TechFolio.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditsController : ControllerBase
    {
        private readonly AppDbContext _context; // Променено на AppDbContext
        private readonly IAuthorizationService _authorizationService;

        public CreditsController(
            AppDbContext context, // Променено тук
            IAuthorizationService authorizationService)
        {
            _context = context;
            _authorizationService = authorizationService;
        }

        // POST: api/credits
        [HttpPost]
        [Authorize(Roles = "Student")]
        public async Task<ActionResult<CreditDto>> AddCredit(CreditUploadRequest request)
        {
            if (!ModelState.IsValid) return BadRequest();

            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var existingCredits = await _context.Credits
                .Where(c => c.StudentId == studentId && c.Category == request.Category)
                .SumAsync(c => c.Amount);

            var categoryLimit = GetCategoryLimit(request.Category);
            if (existingCredits + request.Amount > categoryLimit)
                return BadRequest("Category limit exceeded");

            var credit = new Credit
            {
                StudentId = studentId,
                Category = request.Category,
                Amount = request.Amount,
                Description = request.Description,
                DateAdded = DateTime.UtcNow,
                IsUsed = false
            };

            _context.Credits.Add(credit);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCredit), new { id = credit.Id }, MapToDto(credit));
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<CreditDto>> GetCredit(int id)
        {
            var credit = await _context.Credits.FindAsync(id);
            if (credit == null) return NotFound();

            return MapToDto(credit);
        }

        private CreditDto MapToDto(Credit credit) => new CreditDto
        {
            Id = credit.Id,
            Category = credit.Category,
            Amount = credit.Amount,
            Description = credit.Description,
            DateAdded = credit.DateAdded,
            IsUsed = credit.IsUsed
        };

        private int GetCategoryLimit(CreditCategory category) => category switch
        {
            CreditCategory.Academic => 100,
            CreditCategory.Extracurricular => 50,
            CreditCategory.CommunityService => 50,
            _ => 0
        };
    }
}