using Attendance.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Attendance.Server.Data.EntityConfigs;

public class RoleClaimConfig : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.ToTable("RoleClaim");
        builder.Property(p => p.ClaimType).IsUnicode(false).HasMaxLength(50);
        builder.Property(p => p.ClaimValue).IsUnicode(false).HasMaxLength(50);
    }
}
