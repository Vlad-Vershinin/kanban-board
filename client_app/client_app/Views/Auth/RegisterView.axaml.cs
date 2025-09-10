using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using client_app.ViewModels.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace client_app.Views.Auth;

public partial class RegisterView : UserControl
{
    public RegisterView()
    {
        InitializeComponent();
        DataContext = App.ServiceProvider.GetService<RegisterViewModel>();
    }
}