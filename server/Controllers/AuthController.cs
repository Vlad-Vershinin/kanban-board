using Microsoft.AspNetCore.Mvc;
using server.Models.Dto;
using server.Services;
using System.Diagnostics;

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
}
