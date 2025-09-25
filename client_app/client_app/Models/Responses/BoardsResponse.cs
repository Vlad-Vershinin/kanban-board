using System.Collections.ObjectModel;

namespace client_app.Models.Responses;

public class BoardsResponse
{
    public ObservableCollection<Board> Boards { get; set; }
}
