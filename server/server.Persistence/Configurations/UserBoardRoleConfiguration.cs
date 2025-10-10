using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Models;

namespace server.Persistence.Configurations;

public class UserBoardRoleConfiguration : IEntityTypeConfiguration<UserBoardRole>
{
    public void Configure(EntityTypeBuilder<UserBoardRole> builder)
    {
        throw new NotImplementedException();
    }
}
