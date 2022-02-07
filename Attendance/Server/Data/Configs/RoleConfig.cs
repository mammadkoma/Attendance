using Attendance.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Attendance.Server.Data.Configs;

public class RoleConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");
        builder.Property(p => p.Name).IsUnicode(false).HasMaxLength(50).IsRequired();
        builder.Property(p => p.NormalizedName).IsUnicode(false).HasMaxLength(50).IsRequired();
        builder.Property(p => p.ConcurrencyStamp).IsUnicode(false);

        // seed
        builder.HasData(
            new Role { Id = 1, Name = "admin", NormalizedName = "ADMIN" },
            new Role { Id = 2, Name = "user", NormalizedName = "USER" }
        );
    }
}