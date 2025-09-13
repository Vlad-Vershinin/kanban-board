using client_app.Views.Pages;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive;
using System.Threading.Tasks;

namespace client_app.ViewModels.Pages;

public class CreateBoardViewModel : ViewModelBase
{
    private const string url = "http://localhost:7084/api";
    private readonly HttpClient httpClient_ = new();

    [Reactive] public string Name { get; set; } = string.Empty;
    
    [Reactive] public string NameWarnigs { get; set; } = string.Empty;

    public ReactiveCommand<Unit, Unit> CloseCommand { get; set; }
    public ReactiveCommand<Unit, Unit> CreateBoardCommand { get; set; }

    public CreateBoardViewModel()
    {
        CloseCommand = ReactiveCommand.CreateFromTask(Close);
        CreateBoardCommand = ReactiveCommand.CreateFromTask(CreateBoard);
    }

    private async Task Close()
    {
        var window = App.ServiceProvider.GetService<CreateBoardView>();
        window.Close();
    }

    private async Task CreateBoard()
    {
        NameWarnigs = string.Empty;
        if (string.IsNullOrWhiteSpace(Name))
        {
            NameWarnigs = "The name cannot be empty.";
            return;
        }

        var response = await httpClient_.PostAsJsonAsync($"{url}/board/create", new { Name });

        if (response.IsSuccessStatusCode)
        {
            await Close();
        }
        else
        {
            NameWarnigs = "Unknown error during creation";
        }
    }
}
