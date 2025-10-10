using Microsoft.EntityFrameworkCore;
using server.Domain.Models;

namespace server.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
    {
        throw new NotImplementedException();
    }
}
