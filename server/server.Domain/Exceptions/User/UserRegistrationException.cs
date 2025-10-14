namespace server.Domain.Exceptions.User;

public class UserRegistrationException : DomainException
{
    public UserRegistrationException(string message) : base(message)
    {
    }
}
