using Microsoft.AspNetCore.Mvc;
using server.Core.Interfaces.Services;
using server.Core.DTOs.Auth;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IPasswordService _passwordService;

    public AuthController(IUserService userService, IPasswordService passwordService)
    {
        _userService = userService;
        _passwordService = passwordService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto login)
    {
        var isValid = await _userService.ValidateCredentialsAsync(login.Login, login.Password);
        if (isValid)
        {
            var user = await _userService.GetUserByLoginAsync(login.Login);
            return Ok(user);
        }

        return Unauthorized();
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
        var passwordResult = _passwordService.CheckPassword(register.Password);

        if (passwordResult != string.Empty)
        {
            return Unauthorized(new { mewssage = passwordResult });
        }

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
