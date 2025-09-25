using client_app.Models;
using client_app.Models.Responses;
using client_app.Services;
using client_app.Views.Pages;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive;
using System.Threading.Tasks;

namespace client_app.ViewModels.Pages;

public class CreateBoardViewModel : ViewModelBase
{
    private readonly BoardService _boardService;
    private readonly IHttpClientService _httpClientService;

    [Reactive] public string Name { get; set; } = string.Empty;
    
    [Reactive] public string NameWarnigs { get; set; } = string.Empty;

    public ReactiveCommand<Unit, Unit> CloseCommand { get; set; }
    public ReactiveCommand<Unit, Unit> CreateBoardCommand { get; set; }

    public CreateBoardViewModel(IHttpClientService httpClientService)
    {
        _httpClientService = httpClientService;

        _boardService = App.ServiceProvider.GetService<BoardService>();

        CloseCommand = ReactiveCommand.Create(Close);
        CreateBoardCommand = ReactiveCommand.CreateFromTask(CreateBoard);

        LoadBoards();
    }

    private void LoadBoards()
    {
    }

    private void Close()
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

        var userId = App.ServiceProvider.GetService<UserService>(); 

        var response = await _httpClientService.PostAsJsonAsync($"board/create", new { userId, Name });

        if (response.IsSuccessStatusCode)
        {
            var newBoard = new Board();
            newBoard.Name = Name;

            _boardService.AddBoard(newBoard);
            Close();
        }
        else
        {
            NameWarnigs = "Unknown error during creation";
        }
    }
}
