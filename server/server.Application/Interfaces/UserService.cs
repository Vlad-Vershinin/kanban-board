using server.Application.Interfaces.Repositories;
using server.Domain.DTOs;
using server.Domain.Interfaces.Services;
using server.Domain.Models;
using System;
using System.Threading.Tasks;
using server.Domain.Exceptions.User;

namespace server.Application.Interfaces;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IPasswordService _passwordService;
    private readonly IJwtService _jwtService;

    public UserService(
        IUserRepository repository, 
        IPasswordService passwordService,
        IJwtService jwtService)
    {
        _repository = repository;
        _passwordService = passwordService;
        _jwtService = jwtService;
    }

    public async Task RegisterUser(RegisterDto registerDto)
    {
        if (await _repository.IsUserExistByLogin(registerDto.Login))
            throw new UserRegistrationException("Пользователь с таким логином уже существует");

        var user = new User()
        {
            Id = Guid.NewGuid(),
            Login = registerDto.Login,
            Email = registerDto.Email,
            Password = _passwordService.HashPassword(registerDto.Password),
            UserName = registerDto.Login
        };

        await _repository.AddUser(user);
    }

    public async Task<string> LoginUser(LoginDto loginDto)
    {
        if (!await _repository.IsUserExistByLogin(loginDto.Login))
            throw new UserLoginException("Такого пользователя не существует");

        var user = await _repository.GetUserByLogin(loginDto.Login);

        var result = _passwordService.ValidatePassword(loginDto.Password, user.Password);

        if (result == false)
            throw new UserLoginException("Логин или пароль неверный");

        var token = _jwtService.GenerateToken(user);

        return token;
    }
}
