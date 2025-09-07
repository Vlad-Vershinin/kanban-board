using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

namespace server.Services;

public class UserService : IUserService
{
    private readonly DataContext _context;

    public UserService(DataContext context)
    {
        _context = context;

        if (_context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }
    }

    public async Task<User> GetUserByLoginAsync(string login)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
    }

    public async Task<bool> ValidateUserAsync(string login, string password)
    {
        var user = await GetUserByLoginAsync(login);

        return user != null && VerifyPassword(password, user.Password);
    }

    public async Task CreateUserAsync(User user)
    {
        user.Password = HashPassword(user.Password);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    private bool VerifyPassword(string password, string hashPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashPassword);
    }
}
