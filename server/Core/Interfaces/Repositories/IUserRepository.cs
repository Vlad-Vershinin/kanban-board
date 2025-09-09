using server.Core.Entities;

namespace server.Core.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User> GetUserByLoginAsync(string login);
    Task<bool> ValidateUserAsync(string login, string password);
    Task CreateUserAsync(User user);
}
