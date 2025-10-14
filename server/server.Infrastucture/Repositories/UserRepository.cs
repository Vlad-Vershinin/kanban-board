using Microsoft.EntityFrameworkCore;
using server.Application.Interfaces.Repositories;
using server.Domain.Models;
using server.Persistence;
using System;
using System.Threading.Tasks;

namespace server.Infrastucture.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddUser(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User> GetUserById(Guid id)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id); 
    }

    public async Task<User> GetUserByLogin(string login)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Login == login);
    }

    public async Task<bool> IsUserExistById(Guid id)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .AnyAsync(u => u.Id == id);
    }

    public async Task<bool> IsUserExistByLogin(string login)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .AnyAsync(u => u.Login == login);
    }
}
