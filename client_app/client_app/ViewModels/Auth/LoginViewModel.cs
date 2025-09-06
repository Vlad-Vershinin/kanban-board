using client_app.Services;
using client_app.Views.Auth;
using ReactiveUI;
using System.Diagnostics;
using System.Reactive;

namespace client_app.ViewModels.Auth;

public class LoginViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    public ReactiveCommand<Unit, Unit> GoToRegisteCommand { get; }

    public LoginViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        GoToRegisteCommand = ReactiveCommand.Create(() =>
        {
            _navigationService.NavigateTo<RegisterView>();
        });
    }
}
