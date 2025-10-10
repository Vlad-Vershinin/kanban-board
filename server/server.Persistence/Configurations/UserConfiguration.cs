using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Models;

namespace server.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder
            .HasMany(u => u.CreatedBoards)
            .WithOne(b => b.Creator)
            .HasForeignKey(b => b.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(u => u.Boards)
            .WithOne(ubr => ubr.User)
            .HasForeignKey(ubr => ubr.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
