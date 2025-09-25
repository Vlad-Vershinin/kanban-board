using Microsoft.AspNetCore.Mvc;
using server.Core.DTOs.Board;
using server.Core.Interfaces.Services;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BoardController : ControllerBase
{
    private readonly IBoardService _boardService;

    public BoardController(IBoardService boardService)
    {
        _boardService = boardService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateBoardDto board)
    {
        var result = await _boardService.CreateBoard(board);
        
        if (result)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpGet("load")]
    public async Task<IActionResult> Load([FromQuery] string id)
    {
        

        return Ok();
    }
}
