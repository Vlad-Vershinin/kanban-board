using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Core.Entities;

namespace server.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u =>u.Id);

        builder
            .HasMany(u => u.CreatedBoards)
            .WithOne(b => b.Creator)
            .HasForeignKey(b => b.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(u => u.Boards)
            .WithMany(b => b.Users);
    }
}
