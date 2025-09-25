using Microsoft.EntityFrameworkCore;
using server.Core.Entities;

namespace server.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Board> Boards { get; set; }
    public DbSet<Column> Columns { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<UserBoards> UserBoards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserBoards>()
            .HasKey(ub => new { ub.UserId, ub.BoardId });

        modelBuilder.Entity<UserBoards>()
            .HasOne(ub => ub.User)
            .WithMany(u => u.UserBoards)
            .HasForeignKey(ub => ub.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserBoards>()
            .HasOne(ub => ub.Board)
            .WithMany(b => b.UserBoards)
            .HasForeignKey(ub => ub.BoardId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Board>()
            .HasOne(b => b.Creator)
            .WithMany()
            .HasForeignKey(b => b.CreatorId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
