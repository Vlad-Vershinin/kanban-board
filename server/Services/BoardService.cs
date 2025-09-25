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

    public async Task<Board> GetBoard(Guid id)
    {
        return await _boardRepository.GetBoardByIdAsync(id);
    }

    public async Task<bool> CreateBoard(CreateBoardDto board)
    {
        Debug.WriteLine(board.CreatorId);

        var user = _userRepository.GetUserByIdAsync(board.CreatorId);

        if (user == null || string.IsNullOrEmpty(board.Name))
        {
            return false;
        }

        var newBoard = new Board();
        newBoard.Id = Guid.NewGuid();
        newBoard.Name = board.Name;
        newBoard.Description = string.Empty;
        newBoard.CreatorId = board.CreatorId;

        await _boardRepository.CreateBoardAsync(newBoard);
        return true;
    }
}
