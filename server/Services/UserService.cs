using server.Core.DTOs.Auth;
using server.Core.Entities;
using server.Core.Interfaces.Repositories;
using server.Core.Interfaces.Services;

namespace server.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> RegisterUserAsync(RegisterDto registerDto)
    {
        var existingUser = await _userRepository.GetUserByLoginAsync(registerDto.Login);
        if (existingUser != null)
        {
            return false;
        }

        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Login = registerDto.Login,
            Password = registerDto.Password,
            VisibleName = registerDto.Login
        };

        await _userRepository.CreateUserAsync(newUser);
        return true;
    }

    public async Task<bool> IsUserExist(string login)
    {
        var user = await _userRepository.GetUserByLoginAsync(login);

        return user != null;
    }

    public async Task<bool> ValidateCredentialsAsync(string login, string password)
    {
        var user = await _userRepository.GetUserByLoginAsync(login);

        return user != null && user.Password == password;
    }
}
