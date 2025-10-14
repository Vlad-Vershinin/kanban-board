namespace server.Domain.Interfaces.Services;

public interface IPasswordService
{
    public string HashPassword(string password);
    public bool ValidatePassword(string password, string hashPassword);
}
