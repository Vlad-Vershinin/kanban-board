using Microsoft.EntityFrameworkCore;
using server.Core.Entities;
using server.Core.Interfaces.Repositories;
using server.Infrastructure.Data;

namespace server.Infrastructure.Repositories;

public class UserBoardsRepository : IUserBoardsRepository
{
    private readonly ApplicationDbContext _context;

    public UserBoardsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddUserToBoardAsync(UserBoards userBoard)
    {
        _context.UserBoards.Add(userBoard);
        await _context.SaveChangesAsync();
    }

    public async Task<List<UserBoards>> GetBoardUsersAsync(Guid boardId)
    {
        return await _context.UserBoards
            .Where(ub => ub.BoardId == boardId)
            .Include(ub => ub.Board)
            .ToListAsync();
    }

    public async Task<List<UserBoards>> GetUserBoardsAsync(Guid userId)
    {
        return await _context.UserBoards
            .Where(ub => ub.UserId == userId)
            .Include(ub => ub.Board)
            .ToListAsync();
    }
}
