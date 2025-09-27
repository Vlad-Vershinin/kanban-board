using server.Core.Entities;

namespace server.Core.Interfaces.Repositories;

public interface IUserBoardsRepository
{
    Task AddUserToBoardAsync(UserBoards userBoard);
    Task<List<UserBoards>> GetUserBoardsAsync(Guid userId);
    Task<List<UserBoards>> GetBoardUsersAsync(Guid boardId);
}
