using client_app.Services;
using client_app.Views.Auth;
using client_app.Views.Pages;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive;
using System.Threading.Tasks;

namespace client_app.ViewModels.Auth;

public class LoginViewModel : ViewModelBase
{
    private const string url = "http://localhost:7084/api";
    private readonly HttpClient httpClient_ = new();

    [Reactive] public char PasswordSymbol { get; set; } = '•';

    [Reactive] public string Login { get; set; }
    [Reactive] public string Password { get; set; }

    [Reactive] public bool AuthWarning { get; set; } = false;


    private readonly INavigationService _navigationService;
    public ReactiveCommand<Unit, Unit> GoToRegisteCommand { get; }
    public ReactiveCommand<Unit, Unit> ChangePasswordVisibilityCommand { get; }
    public ReactiveCommand<Unit, Unit> LoginCommand { get; }

    public LoginViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        GoToRegisteCommand = ReactiveCommand.Create(() =>
        {
            _navigationService.NavigateTo<RegisterView>();
        });
        ChangePasswordVisibilityCommand = ReactiveCommand.Create(ChangePasswordVisibility);
        LoginCommand = ReactiveCommand.CreateFromTask(LoginAsync);
    }

    private void ChangePasswordVisibility()
    {
        if (PasswordSymbol == '•') PasswordSymbol = '\0';
        else PasswordSymbol = '•';
    }

    private async Task LoginAsync()
    {
        var response = await httpClient_.PostAsJsonAsync($"{url}/Auth/login", new
        {
            Login,
            Password
        });

        if (response.IsSuccessStatusCode)
        {
            _navigationService.NavigateTo<MainPageView>();
        }
        else
        {
            AuthWarning = true;
        }
    }
}
