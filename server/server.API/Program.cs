namespace server.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("Dev", policy =>
            {
                policy.WithOrigins("http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors("Dev");

        app.UseAuthorization();

        app.Run();
    }
}
