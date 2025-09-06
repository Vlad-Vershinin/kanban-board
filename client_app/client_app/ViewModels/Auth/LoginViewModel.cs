using client_app.Services;
using client_app.Views.Auth;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive;

namespace client_app.ViewModels.Auth;

public class LoginViewModel : ViewModelBase
{
    [Reactive] public char PasswordSymbol { get; set; } = '•';


    private readonly INavigationService _navigationService;
    public ReactiveCommand<Unit, Unit> GoToRegisteCommand { get; }
    public ReactiveCommand<Unit, Unit> ChangePasswordVisibilityCommand { get; set; }

    public LoginViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        GoToRegisteCommand = ReactiveCommand.Create(() =>
        {
            _navigationService.NavigateTo<RegisterView>();
        });
        ChangePasswordVisibilityCommand = ReactiveCommand.Create(ChangePasswordVisibility);
    }

    private void ChangePasswordVisibility()
    {
        if (PasswordSymbol == '•') PasswordSymbol = '\0';
        else PasswordSymbol = '•';
    }
}
