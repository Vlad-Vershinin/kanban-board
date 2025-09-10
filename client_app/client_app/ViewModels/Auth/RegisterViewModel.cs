using client_app.Models.Responses;
using client_app.Services;
using client_app.Views.Auth;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace client_app.ViewModels.Auth;

public class RegisterViewModel : ViewModelBase
{
    private const string url = "http://localhost:7084/api";
    private readonly HttpClient httpClient_ = new();

    [Reactive] public char PasswordSymbol { get; set; } = '•';

    [Reactive] public string Login { get; set; }
    [Reactive] public string Password { get; set; }
    [Reactive] public string RepeatPassword { get; set; }

    [Reactive] public string PasswordWarning { get; set; }
    [Reactive] public bool IsPasswordsSimilar { get; set; } = false;
    [Reactive] public bool IsRegisterButtonActivate { get; set; } = true;
    [Reactive] public bool IsLoginEmpty { get; set; } = false;
    [Reactive] public bool IsUserCreated { get; set; } = false;

    private readonly INavigationService _navigationService;
    public ReactiveCommand<Unit, Unit> GoToLoginCommand { get; }
    public ReactiveCommand<Unit, Unit> ChangePasswordVisibilityCommand { get; }
    public ReactiveCommand<Unit, Unit> RegisterCommand { get; }

    public RegisterViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        GoToLoginCommand = ReactiveCommand.Create(() =>
        {
            _navigationService.NavigateTo<LoginView>();
        });
        ChangePasswordVisibilityCommand = ReactiveCommand.Create(ChangePasswordVisibility);
        RegisterCommand = ReactiveCommand.CreateFromTask(Register);

    }

    private void ChangePasswordVisibility()
    {
        if (PasswordSymbol == '•') PasswordSymbol = '\0';
        else PasswordSymbol = '•';
    }

    private async Task Register()
    {
        IsRegisterButtonActivate = false;
        IsLoginEmpty = false;
        IsUserCreated = false;

        if (string.IsNullOrWhiteSpace(Login))
        {
            IsLoginEmpty = true;
            IsRegisterButtonActivate = true;
            return;
        }

        if (!CheckPassword() || !CheckPasswords())
        {
            IsRegisterButtonActivate = true;
            return;
        }

        var checkResponse = await httpClient_.GetAsync($"{url}/auth/check?login={Uri.EscapeDataString(Login)}");
        if (checkResponse.IsSuccessStatusCode)
        {
            var content = await checkResponse.Content.ReadFromJsonAsync<CheckResponse>();
            if (content.Exists)
            {
                IsUserCreated = true;
                IsRegisterButtonActivate = true;
                return;
            }
        }

        var response = await httpClient_.PostAsJsonAsync($"{url}/auth/register", new
        {
            Login,
            Password
        });

        if (response.IsSuccessStatusCode)
        {
            _navigationService.NavigateTo<LoginView>();
        }
        else
        {
            Debug.WriteLine($"Registration failed: {response.StatusCode}");
            IsRegisterButtonActivate = true;
        }
    }

    private bool CheckPassword()
    {
        PasswordWarning = string.Empty;
        if (string.IsNullOrEmpty(Password))
        {
            PasswordWarning = "The password must not be empty.";
            return false;
        }

        var warnings = new List<string>();

        if (Password.Length < 8)
            warnings.Add("• At least 8 characters");

        if (!Regex.IsMatch(Password, "[a-zа-я]"))
            warnings.Add("• At least one letter");

        if (!Regex.IsMatch(Password, "[A-ZА-Я]"))
            warnings.Add("• At least one capital letter");

        if (!Regex.IsMatch(Password, "[!@#$%^&*()_+\\-=\\[\\]{};':\"\\\\|,.<>\\/?]"))
            warnings.Add("• At least one special character (!@#$%^&* etc.)");

        if (!Regex.IsMatch(Password, "[0-9]"))
            warnings.Add("• At least one digit");

        if (warnings.Count == 0)
        {
            return true;
        }
        else
        {
            PasswordWarning = "The password must be:\n" + string.Join("\n", warnings);
            return false;
        }
    }

    private bool CheckPasswords()
    {
        if (Password != RepeatPassword)
        {
            IsPasswordsSimilar = true;
            return false;
        }
        else
        {
            IsPasswordsSimilar = false;
            return true;
        }
    }
}