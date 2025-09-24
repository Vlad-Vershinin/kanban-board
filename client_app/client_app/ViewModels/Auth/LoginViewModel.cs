using client_app.Models.Responses;
using client_app.Services;
using client_app.Views.Auth;
using client_app.Views.Pages;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using server.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive;
using System.Threading.Tasks;

namespace client_app.ViewModels.Auth;

public class LoginViewModel : ViewModelBase
{
    [Reactive] public char PasswordSymbol { get; set; } = '•';

    [Reactive] public string Login { get; set; }
    [Reactive] public string Password { get; set; }

    [Reactive] public bool AuthWarning { get; set; } = false;


    private readonly INavigationService _navigationService;
    private readonly IUserService _userService;
    private readonly IHttpClientService _httpClientService;

    public ReactiveCommand<Unit, Unit> GoToRegisteCommand { get; }
    public ReactiveCommand<Unit, Unit> ChangePasswordVisibilityCommand { get; }
    public ReactiveCommand<Unit, Unit> LoginCommand { get; }

    public LoginViewModel(INavigationService navigationService, IUserService userService, IHttpClientService httpClientService)
    {
        _navigationService = navigationService;
        _userService = userService;
        _httpClientService = httpClientService;

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
        var response = await _httpClientService.PostAsJsonAsync($"auth/login", new
        {
            Login,
            Password
        });

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<UserResponse>();

            var user = new User
            {
                Id = content.Id,
                Login = content.Login,
                Password = content.Password,
                Email = content.Email,
                VisibleName = content.VisibleName,
                CreatedAt = content.CreatedAt
            };

            _userService.SetUser(user);

            _navigationService.NavigateTo<MainPageView>();
        }
        else
        {
            AuthWarning = true;
        }
    }
}
