using Avalonia.Controls;
using client_app.ViewModels.Auth;
using client_app.Views.Auth;
using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace client_app.Services;

public class NavigationService : ReactiveObject
{
    [Reactive] public UserControl CurrentUserControl { get; }

    private LoginView LoginView;

    public NavigationService()
    {
        LoginView = new LoginView { DataContext = new LoginViewModel(this)};

        CurrentUserControl = LoginView;
    }


}
