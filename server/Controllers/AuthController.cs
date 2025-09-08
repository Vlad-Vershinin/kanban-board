using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Models.Dto;
using server.Services;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto login)
    {
        var isValid = await _userService.ValidateUserAsync(login.Login, login.Password);

        if (isValid)
        {
            return Ok();
        }

        return Unauthorized();
    }

    [HttpGet("check")]
    public async Task<IActionResult> СheckUser([FromQuery] string login)
    {
        var user = await _userService.GetUserByLoginAsync(login);

        return Ok(new { exists = user != null });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto register)
    {
        var existingUser = await _userService.GetUserByLoginAsync(register.Login);

        if (existingUser != null)
        {
            return Conflict(new { message = "User already exists" });
        }

        var newUser = new User();
        newUser.Id = Guid.NewGuid();
        newUser.Login = register.Login;
        newUser.Password = register.Password;
        newUser.VisibleName = register.Login;

        try
        {
            await _userService.CreateUserAsync(newUser);
            return Ok(new { message = "User created successfully" });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating user: {ex.Message}");
            return StatusCode(500, new { message = "Internal server error" });
        }
    }
}
