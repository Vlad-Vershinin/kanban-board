using Microsoft.AspNetCore.Mvc;
using server.Core.Interfaces.Services;
using server.Core.DTOs.Auth;

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
        var isValid = await _userService.ValidateCredentialsAsync(login.Login, login.Password);
        return isValid ? Ok() : Unauthorized();
    }

    [HttpGet("check")]
    public async Task<IActionResult> СheckUser([FromQuery] string login)
    {
        var isUserExist = await _userService.IsUserExist(login);

        return Ok(new { exists = isUserExist });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto register)
    {
        var result = await _userService.RegisterUserAsync(register);

        if (result)
        {
            return Ok(new { message = "User created successfully" });
        }
        else
        {
            return Conflict(new { message = "User already exists" });
        }
    }
}
