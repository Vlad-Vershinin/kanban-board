using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using client_app.Services;
using client_app.ViewModels;
using client_app.ViewModels.Auth;
using client_app.ViewModels.Pages;
using client_app.Views;
using client_app.Views.Auth;
using client_app.Views.Pages;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace client_app;

public partial class App : Application
{
    private IServiceProvider _serviceProvider;
    public static IServiceProvider ServiceProvider { get; private set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var services = new ServiceCollection();

        services.AddSingleton<INavigationService, NavigationService>();

        services.AddSingleton<MainViewModel>();
        services.AddSingleton<LoginViewModel>();
        services.AddSingleton<RegisterViewModel>();
        services.AddSingleton<MainPageViewModel>();
        services.AddTransient<CreateBoardViewModel>();

        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainView>();
        services.AddSingleton<LoginView>();
        services.AddSingleton<RegisterView>();
        services.AddSingleton<MainPageView>();
        services.AddSingleton<CreateBoardView>();

        _serviceProvider = services.BuildServiceProvider();
        ServiceProvider = _serviceProvider;

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();

            var mainViewModel = _serviceProvider.GetService<MainViewModel>();

            mainWindow.DataContext = mainViewModel;
            desktop.MainWindow = mainWindow;

            var navigationService = _serviceProvider.GetService<INavigationService>();
            navigationService.NavigateTo<LoginView>();
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            var mainView = _serviceProvider.GetService<MainView>();
            var mainViewModel = _serviceProvider.GetService<MainViewModel>();

            mainView.DataContext = mainViewModel;
            singleViewPlatform.MainView = mainView;

            var navigationService = _serviceProvider.GetService<INavigationService>();
            navigationService.NavigateTo<LoginView>();
        }

        base.OnFrameworkInitializationCompleted();
    }
}