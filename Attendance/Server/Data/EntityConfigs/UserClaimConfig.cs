using Attendance.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Attendance.Server.Data.EntityConfigs;

public class UserClaimConfig : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.ToTable("UserClaim");
        builder.Property(p => p.ClaimType).IsUnicode(false).HasMaxLength(50);
        builder.Property(p => p.ClaimValue).IsUnicode(false).HasMaxLength(50);
    }
}
