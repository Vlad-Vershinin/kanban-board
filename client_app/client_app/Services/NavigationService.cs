using Avalonia.Controls;
using ReactiveUI;
using ReactiveUI.SourceGenerators;
using System.Collections.Generic;
using System;

namespace client_app.Services;

public class NavigationService : ReactiveObject, INavigationService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly Stack<UserControl> _navigationStack;

    [Reactive]
    public UserControl CurrentUserControl { get; set; }

    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _navigationStack = new Stack<UserControl>();
    }

    public bool CanGoBack => _navigationStack.Count > 0;

    public void NavigateTo<T>() where T : UserControl
    {
        NavigateTo(typeof(T));
    }

    public void NavigateTo(Type userControlType)
    {
        if (!typeof(UserControl).IsAssignableFrom(userControlType))
            throw new ArgumentException("Type must be a UserControl");

        if (CurrentUserControl != null)
        {
            _navigationStack.Push(CurrentUserControl);
        }

        CurrentUserControl = (UserControl)_serviceProvider.GetService(userControlType);

        if (CurrentUserControl == null)
            throw new InvalidOperationException($"UserControl {userControlType.Name} is not registered in DI container");

        this.RaisePropertyChanged(nameof(CurrentUserControl));
    }

    public void GoBack()
    {
        if (!CanGoBack)
            return;

        CurrentUserControl = _navigationStack.Pop();
        this.RaisePropertyChanged(nameof(CurrentUserControl));
    }
}
