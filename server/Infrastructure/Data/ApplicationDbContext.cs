using Microsoft.EntityFrameworkCore;
using server.Core.Entities;

namespace server.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Board> Boards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
