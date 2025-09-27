using server.Core.DTOs.Board;
using server.Core.Entities;

namespace server.Core.Interfaces.Services;

public interface IBoardService
{
    Task<Board> GetBoard(Guid id);
    Task<bool> CreateBoard(CreateBoardDto board);
    Task<List<BoardDto>> GetBoardsByIdAsync(Guid id);
}
