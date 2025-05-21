using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TechFolio.Server.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly UserManager<User> _userManager;
    private readonly JwtService _jwtService;

    public AuthController(UserManager<User> _userManager, ILogger<AuthController> logger, JwtService jwtService)
    {
        this._userManager = _userManager;
        _logger = logger;
        _jwtService = jwtService;
    }

    [HttpGet("login")]
    public ActionResult LoginGet()
    {
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginPost(LoginDTO loginDTO)
    {
        var user = await _userManager.FindByNameAsync(loginDTO.Username);

        if (user == null || !await _userManager.CheckPasswordAsync(user, loginDTO.Password))
            return Unauthorized("Invalid credentials.");

        var token = _jwtService.GenerateToken(user);

        return Ok(new { accessToken = token });
    }

    [HttpGet("register")]
    public ActionResult RegisterGet()
    {
        return Ok();
    }

    [HttpPost("register")]
    public async Task<ActionResult> RegisterPostAsync(RegisterDTO registerDTO)
    {
        User user = new User();

        user.UserName = registerDTO.Username;
        user.Email = registerDTO.Email;

        user.role = registerDTO.UserRole;

        if (registerDTO.Password != registerDTO.ConfirmPassword) return BadRequest();

        var result = await _userManager.CreateAsync(user, registerDTO.Password);

        if (result.Succeeded)
        {
            return Ok("User created.");
        }
        else
        {
            // Log errors
            foreach (var error in result.Errors)
            {
                _logger.LogError($"Error creating user: {error.Code} - {error.Description}");
            }
            return BadRequest(result.Errors);
        }
    }
}
