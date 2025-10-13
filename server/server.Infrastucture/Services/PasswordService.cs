namespace server.Infrastucture.Services;

public class PasswordService
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
