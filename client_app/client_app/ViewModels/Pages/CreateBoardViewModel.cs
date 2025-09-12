using client_app.Views.Pages;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive;
using System.Threading.Tasks;

namespace client_app.ViewModels.Pages;

public class CreateBoardViewModel : ViewModelBase
{
    [Reactive] public string Name { get; set; }

    public ReactiveCommand<Unit, Unit> CloseCommand { get; set; }

    public CreateBoardViewModel()
    {
        CloseCommand = ReactiveCommand.CreateFromTask(Close);
    }

    private async Task Close()
    {
        var window = App.ServiceProvider.GetService<CreateBoardView>();
        window.Close();
    }
}
