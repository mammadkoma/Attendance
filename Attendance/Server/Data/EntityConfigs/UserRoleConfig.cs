using Attendance.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Attendance.Server.Data.EntityConfigs;

public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRole").HasKey(ur => new { ur.Id });
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.HasKey(u => new { u.UserId, u.RoleId });
        builder.Property(p => p.Id).HasColumnOrder(1);

        // seed
        builder.HasData(
            new UserRole { Id = 1, UserId = 1, RoleId = 1 }
        );
    }
}