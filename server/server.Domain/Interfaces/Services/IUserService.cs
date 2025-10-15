using server.Domain.DTOs;
using System.Threading.Tasks;

namespace server.Domain.Interfaces.Services;

public interface IUserService
{
    Task RegisterUser(RegisterDto registerDto);
    Task<string> LoginUser(LoginDto loginDto);
}
