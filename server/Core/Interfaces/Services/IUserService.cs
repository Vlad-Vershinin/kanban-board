using server.Core.DTOs.Auth;
using server.Core.Entities;

namespace server.Core.Interfaces.Services;

public interface IUserService
{
    Task<bool> RegisterUserAsync(RegisterDto registerDto);
    Task<bool> IsUserExist(string login);
    Task<bool> ValidateCredentialsAsync(string login, string password);
}
