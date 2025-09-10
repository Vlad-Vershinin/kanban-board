using Avalonia.Controls;
using client_app.ViewModels;
using client_app.ViewModels.Pages;
using Microsoft.Extensions.DependencyInjection;

namespace client_app.Views.Pages;

public partial class MainPageView : UserControl
{
    public MainPageView()
    {
        InitializeComponent();
        DataContext = App.ServiceProvider.GetService<MainPageViewModel>();
    }
}