using Avalonia.Input;
using client_app.Services;
using client_app.Views.Auth;
using ReactiveUI;
using System.Diagnostics;
using System.Reactive;

namespace client_app.ViewModels.Auth;

public class RegisterViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    public ReactiveCommand<Unit, Unit> GoToLoginCommand { get; }

    public RegisterViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        GoToLoginCommand = ReactiveCommand.Create(() =>
        {
            _navigationService.NavigateTo<LoginView>();
        });
    }
}
