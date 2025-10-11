using server.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Application.Interfaces.Repositories;

public interface IBoardRepository
{
    Task<Board> GetBoardById(Guid id);
    Task<List<Board>> GetBoardsByUserId(Guid id);
    Task AddBoard(Board board);
}
