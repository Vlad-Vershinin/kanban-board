using server.Domain.Models;
using System;
using System.Threading.Tasks;

namespace server.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<bool> IsUserExistById(Guid id);
    Task<bool> IsUserExistByLogin(string login);
    Task<User> GetUserById(Guid id);
    Task<User> GetUserByLogin(string login);
    Task AddUser(User user);
}
