using server.Application.Interfaces.Repositories;
using server.Domain.DTOs;
using server.Domain.Interfaces.Services;
using server.Domain.Models;
using System;
using System.Threading.Tasks;

namespace server.Application.Interfaces;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task RegisterUser(RegisterDto registerDto)
    {
        var user = new User()
        {
            Id = Guid.NewGuid(),
            Login = registerDto.Login,
            Email = registerDto.Email,
            Password = registerDto.Password,
            UserName = registerDto.Login
        };

        await _repository.AddUser(user);
    }
}
