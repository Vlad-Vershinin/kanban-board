using Microsoft.EntityFrameworkCore;
using server.Core.Entities;
using server.Core.Interfaces.Repositories;
using server.Infrastructure.Data;

namespace server.Infrastructure.Repositories;

public class BoardRepository : IBoardRepository
{
    private readonly ApplicationDbContext _context;

    public BoardRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Board> GetBoardByIdAsync(Guid id)
    {
        return await _context.Boards.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task CreateBoardAsync(Board board)
    {
        await _context.Boards.AddAsync(board);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Board>> GetBoardsByIdAsync(Guid id)
    {
        return await _context.Boards.Where();
    }
}
