using Microsoft.EntityFrameworkCore;
using server.Core.Entities;
using server.Core.Interfaces.Repositories;
using server.Infrastructure.Data;
using System.Diagnostics;

namespace server.Infrastructure.Repositories;

public class BoardRepository : IBoardRepository
{
    private readonly ApplicationDbContext _context;

    public BoardRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Board?> GetBoardByIdAsync(Guid id)
    {
        return await _context.Boards.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task CreateBoardAsync(Board board)
    {
        await _context.Boards.AddAsync(board);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Board>> GetBoardsByUserIdAsync(Guid id)
    {
        var boards = await _context.Boards
                        .Where(b => b.Users.Any(u => u.Id == id))
                        .Include(b => b.Creator)
                        .Include(b => b.Users)
                        .Include(b => b.Columns)
                            .ThenInclude(c => c.Cards)
                        .AsSplitQuery()
                        .ToListAsync();
        
        Debug.WriteLine(boards.Count);
        return boards;
    }
}
