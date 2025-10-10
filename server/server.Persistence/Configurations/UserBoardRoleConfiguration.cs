using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Models;

namespace server.Persistence.Configurations;

public class UserBoardRoleConfiguration : IEntityTypeConfiguration<UserBoardRole>
{
    public void Configure(EntityTypeBuilder<UserBoardRole> builder)
    {
        builder.HasKey(ubr => ubr.Id);

        builder.HasIndex(ubr => new { ubr.UserId, ubr.BoardId })
              .IsUnique();
    }
}
