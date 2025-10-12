using Microsoft.AspNetCore.Mvc;
using server.Domain.DTOs;
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
        await _userService.RegisterUser(dto);

        return Ok();
    }
}
