using FluentValidation;
using server.Domain.DTOs;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace server.Application.Validators.Users;

public class CreateUserValidator : AbstractValidator<RegisterDto>
{
    public CreateUserValidator()
    {
        RuleFor(u => u.Login)
            .NotEmpty().WithMessage("Логин не может быть пустым")
            .Length(3, 32).WithMessage("Длинна логина должна быть от 3 до 32 символов");

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Пароль не может быть пустым")
            .MinimumLength(8).WithMessage("Длинна пароля минимум 8 символов")
            .Must(BeStongPassword).WithMessage("Пароль не надёжный");

        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("Почта не может быть пустой")
            .Must(EmailValidate).WithMessage("Это не почта");
    }

    private bool BeStongPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
            return false;

        var hasUpper = password.Any(char.IsUpper);
        var hasLower = password.Any(char.IsLower);
        var hasDigit = password.Any(char.IsDigit);
        var hasSpecial = password.Any(c => !char.IsLetterOrDigit(c));

        return new[] { hasUpper, hasLower, hasDigit, hasSpecial }.Count(x => x) >= 3;
    }
    
    private bool EmailValidate(string email)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return Regex.IsMatch(email, pattern);
    }
}
