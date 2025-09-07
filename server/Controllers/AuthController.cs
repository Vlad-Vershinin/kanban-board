using Microsoft.AspNetCore.Mvc;
using server.Models.Dto;
using System.Diagnostics;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto login)
    {
        Console.WriteLine($"{login.Login}\n{login.Password}");

        return Ok();
    }
}
