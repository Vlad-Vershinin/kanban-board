namespace server.Domain.Exceptions.User;

public class UserLoginException : DomainException
{
    public UserLoginException(string message) : base(message)
    {
    }
}
