using server.Domain.Models;

namespace server.Domain.Interfaces.Services;

public interface IJwtService
{
    public string GenerateToken(User user);
}
