using client_app.Models;
using client_app.Views;
using client_app.Views.Pages;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;

namespace client_app.ViewModels.Pages;

public class MainPageViewModel : ViewModelBase
{
    public ObservableCollection<Board> Boards { get; set; }

    public Board SelectedBorad { get; set; }


    public ReactiveCommand<Unit, Unit> CreateBoardCommand { get; set; }

    public MainPageViewModel()
    {
        Boards = new ObservableCollection<Board>();

        CreateBoardCommand = ReactiveCommand.CreateFromTask(CreateBoard);
    }

    private async Task CreateBoard()
    {
        await App.ServiceProvider.GetService<CreateBoardView>()
            .ShowDialog(App.ServiceProvider.GetService<MainWindow>());
    }

}
