using FluentValidation;
using server.Domain.DTOs;

namespace server.Application.Validators.Users;

public class LoginUserValidator : AbstractValidator<LoginDto>
{
    public LoginUserValidator()
    {
        RuleFor(u => u.Login)
            .NotEmpty().WithMessage("Логин не может быть пустым");

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Пароль не может быть пустым");
    }
}
