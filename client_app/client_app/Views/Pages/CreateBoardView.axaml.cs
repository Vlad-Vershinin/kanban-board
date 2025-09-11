using Avalonia.Controls;
using client_app.ViewModels.Pages;
using Microsoft.Extensions.DependencyInjection;

namespace client_app.Views.Pages;

public partial class CreateBoardView : Window
{
    public CreateBoardView()
    {
        InitializeComponent();
        DataContext = App.ServiceProvider.GetService<CreateBoardViewModel>();
    }
}