using server.Domain.Interfaces.Services;

namespace server.Infrastucture.Services;

public class PasswordService : IPasswordService
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    }

    public bool ValidatePassword(string password, string hashPassword)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(password, hashPassword);
    }
}
