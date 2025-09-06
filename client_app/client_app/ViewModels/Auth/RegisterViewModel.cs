using client_app.Services;
using client_app.Views.Auth;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive;

namespace client_app.ViewModels.Auth;

public class RegisterViewModel : ViewModelBase
{
    [Reactive] public char PasswordSymbol { get; set; } = '•';


    private readonly INavigationService _navigationService;
    public ReactiveCommand<Unit, Unit> GoToLoginCommand { get; }
    public ReactiveCommand<Unit, Unit> ChangePasswordVisibilityCommand { get; }

    public RegisterViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        GoToLoginCommand = ReactiveCommand.Create(() =>
        {
            _navigationService.NavigateTo<LoginView>();
        });
        ChangePasswordVisibilityCommand = ReactiveCommand.Create(ChangePasswordVisibility);
    }

    private void ChangePasswordVisibility()
    {
        if (PasswordSymbol == '•') PasswordSymbol = '\0';
        else PasswordSymbol = '•';
    }
}
