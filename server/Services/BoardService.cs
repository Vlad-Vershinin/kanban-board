using server.Core.DTOs.Board;
using server.Core.Entities;
using server.Core.Interfaces.Repositories;
using server.Core.Interfaces.Services;
using System.Diagnostics;

namespace server.Services;

public class BoardService : IBoardService
{
    private readonly IBoardRepository _boardRepository;
    private readonly IUserRepository _userRepository;

    public BoardService(IBoardRepository boardRepository, IUserRepository userRepository)
    {
        _boardRepository = boardRepository;
        _userRepository = userRepository;
    }

    public async Task<Board?> GetBoard(Guid id)
    {
        return await _boardRepository.GetBoardByIdAsync(id);
    }

    public async Task<bool> CreateBoard(CreateBoardDto boardDto)
    {
        try
        {
            var board = new Board
            {
                Id = Guid.NewGuid(),
                Name = boardDto.Name,
                CreatorId = boardDto.CreatorId,
            };

            var creator = await _userRepository.GetUserByIdAsync(boardDto.CreatorId);
            if (creator != null)
            {
                board.Users = new List<User> { creator };
            }

            await _boardRepository.CreateBoardAsync(board);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<List<Board>> GetBoardsByUserIdAsync(Guid id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);

        if (user == null)
        {
            return new List<Board>();
        }

        var boards = await _boardRepository.GetBoardsByUserIdAsync(user.Id);

        return boards;
    }
}
