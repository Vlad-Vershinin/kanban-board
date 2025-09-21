using server.Models;

namespace client_app.Services;

public class UserService : IUserService
{
    public User User { get; set; }

    public void SetUser(User user)
    {
        User = user;
    }
}
