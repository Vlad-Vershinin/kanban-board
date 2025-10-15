using Microsoft.AspNetCore.Mvc;
using server.Domain.DTOs;
using server.Domain.Exceptions.User;
using server.Domain.Interfaces.Services;

namespace server.API.Cntrollers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        try
        {
            await _userService.RegisterUser(dto);
            return Ok();
        }
        catch (UserRegistrationException ex) { return BadRequest(ex.Message); }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        try
        {
            var token = await _userService.LoginUser(dto);
            return Ok(token);
        }
        catch (UserLoginException ex) { return BadRequest(ex.Message); }
    }
}
