using server.Models;

namespace client_app.Services;

public interface IUserService
{
    User User { get; }

    void SetUser(User user);
}
