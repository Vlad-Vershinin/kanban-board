using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Models;
using System.Collections.Generic;

namespace server.Persistence.Configurations;

public class IssueConfiguration : IEntityTypeConfiguration<Issue>
{
    public void Configure(EntityTypeBuilder<Issue> builder)
    {
        builder.HasKey(i => i.Id);

        builder
            .HasOne(i => i.Column)
            .WithMany(c => c.Issues)
            .HasForeignKey(i => i.ColumnId);

        builder
            .HasMany(i => i.UsersPerform)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "IssueUserPerform",
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId"),
                j => j
                    .HasOne<Issue>()
                    .WithMany()
                    .HasForeignKey("IssueId"));
    }
}
