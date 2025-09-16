using client_app.Models;
using System.Collections.ObjectModel;

namespace client_app.Services;

public class BoardService
{
    public ObservableCollection<Board> Boards { get; } = new ObservableCollection<Board>();

    public void AddBoard(Board board)
    {
        Boards.Add(board);
    }
}
