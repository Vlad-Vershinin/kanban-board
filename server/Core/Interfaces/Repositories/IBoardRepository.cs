using server.Core.Entities;

namespace server.Core.Interfaces.Repositories;

public interface IBoardRepository
{
    Task<Board> GetBoardByIdAsync(Guid id);
    Task CreateBoardAsync(Board board);
}
