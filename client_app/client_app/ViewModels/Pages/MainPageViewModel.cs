using client_app.Models;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace client_app.ViewModels.Pages;

public class MainPageViewModel : ReactiveObject
{
    public ObservableCollection<Board> Boards { get; set; }

    public Board SelectedBorad { get; set; }

    public MainPageViewModel()
    {
        Boards = new ObservableCollection<Board>();
    }

}
