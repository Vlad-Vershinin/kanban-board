using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Models;

namespace server.Persistence.Configurations;

public class BoardConfiguration : IEntityTypeConfiguration<Board>
{
    public void Configure(EntityTypeBuilder<Board> builder)
    {
        builder.HasKey(b => b.Id);

        builder
            .HasOne(b => b.Creator)
            .WithMany(u => u.CreatedBoards)
            .HasForeignKey(u => u.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(b => b.Users)
            .WithOne(ubr => ubr.Board)
            .HasForeignKey(ubr => ubr.BoardId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(b => b.Columns)
            .WithOne(c => c.Board)
            .HasForeignKey(c => c.BoardId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
