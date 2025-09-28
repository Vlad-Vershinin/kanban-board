using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Core.Entities;

namespace server.Infrastructure.Data.Configurations;

public class BoardConfiguration : IEntityTypeConfiguration<Board>
{
    public void Configure(EntityTypeBuilder<Board> builder)
    {
        builder.HasKey(b =>b.Id);

        builder.Property(b => b.CreatorId)
            .IsRequired();

        builder
            .HasOne(b => b.Creator)
            .WithMany(u => u.CreatedBoards)
            .HasForeignKey(b => b.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(b => b.Users)
            .WithMany(u => u.Boards);

        builder
            .HasMany(b => b.Columns)
            .WithOne(c => c.Board);
    }
}
