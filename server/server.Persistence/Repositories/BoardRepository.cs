using Microsoft.EntityFrameworkCore;
using server.Domain.Interfaces.Repositories;
using server.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Persistence.Repositories;

public class BoardRepository : IBoardRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BoardRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddBoard(Board board)
    {
        await _dbContext.Boards.AddAsync(board);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Board> GetBoardById(Guid id)
    {
        return await _dbContext.Boards.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<List<Board>> GetBoardsByUserId(Guid id)
    {
        return await _dbContext.UserBoardRoles
            .Where(b => b.BoardId == id)
            .Select(ubr => ubr.Board)
            .ToListAsync();
    }
}
