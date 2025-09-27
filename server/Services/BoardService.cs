using server.Core.DTOs.Board;
using server.Core.Entities;
using server.Core.Interfaces.Repositories;
using server.Core.Interfaces.Services;
using server.Infrastructure.Repositories;
using System.Diagnostics;

namespace server.Services;

public class BoardService : IBoardService
{
    private readonly IBoardRepository _boardRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUserBoardsRepository _userBoardsRepository;

    public BoardService(IBoardRepository boardRepository, IUserRepository userRepository, IUserBoardsRepository userBoardsRepository)
    {
        _boardRepository = boardRepository;
        _userRepository = userRepository;
        _userBoardsRepository = userBoardsRepository;
    }

    public async Task<Board> GetBoard(Guid id)
    {
        return await _boardRepository.GetBoardByIdAsync(id);
    }

    public async Task<bool> CreateBoard(CreateBoardDto board)
    {
        Debug.WriteLine(board.CreatorId);

        var user = await _userRepository.GetUserByIdAsync(board.CreatorId);

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

        var userBoard = new UserBoards
        {
            UserId = board.CreatorId,
            BoardId = newBoard.Id
        };

        await _userBoardsRepository.AddUserToBoardAsync(userBoard);

        return true;
    }

    public async Task<List<BoardDto>> GetBoardsByIdAsync(Guid id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);

        if (user == null)
        {
            return new List<BoardDto>();
        }

        var boardsList = await _userBoardsRepository.GetUserBoardsAsync(id);

        var boards = boardsList.Select(ub => new BoardDto
        {
            Id = ub.Board.Id,
            Name = ub.Board.Name,
            Description = ub.Board.Description,
            CreatorId = ub.Board.CreatorId
        }).ToList();

        return boards;
    }
}
