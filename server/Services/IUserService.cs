using server.Models;

namespace server.Services;

public interface IUserService
{
    Task<User> GetUserByLoginAsync(string login);
    Task<bool> ValidateUserAsync(string login, string password);
    Task CreateUserAsync(User user);
}
