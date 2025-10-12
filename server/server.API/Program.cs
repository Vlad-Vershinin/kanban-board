using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using server.Application.Interfaces;
using server.Application.Interfaces.Repositories;
using server.Application.Validators.Users;
using server.Domain.Interfaces.Repositories;
using server.Domain.Interfaces.Services;
using server.Persistence;
using server.Persistence.Repositories;

namespace server.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        // repositories
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IBoardRepository, BoardRepository>();

        // services
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IBoardService, BoardService>();

        builder.Services.AddControllers();

        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddFluentValidationClientsideAdapters();
        builder.Services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("Dev", policy =>
            {
                policy.WithOrigins("http://localhost:3000",
                                   "https://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors("Dev");

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
