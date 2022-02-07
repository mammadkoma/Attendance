using Attendance.Server.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Attendance.Server.Data.Configs;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        var hasher = new PasswordHasher<User>();
        builder.ToTable("User");
        builder.Property(p => p.FirstName).HasMaxLength(50);
        builder.Property(p => p.LastName).HasMaxLength(50);
        builder.Property(p => p.UserName).IsUnicode(false).HasMaxLength(50).IsRequired();
        builder.Property(p => p.NormalizedUserName).IsUnicode(false).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Email).IsUnicode(false).HasMaxLength(50).IsRequired();
        builder.Property(p => p.NormalizedEmail).IsUnicode(false).HasMaxLength(50).IsRequired();
        builder.Property(p => p.PasswordHash).IsUnicode(false).IsRequired();
        builder.Property(p => p.SecurityStamp).IsUnicode(false);
        builder.Property(p => p.ConcurrencyStamp).IsUnicode(false);
        builder.Property(p => p.PhoneNumber).HasColumnName("Mobile").IsUnicode(false).HasMaxLength(11).IsFixedLength(true);

        builder.HasData(
            new User
            {
                Id = 1, // primary key
                FirstName = "محمّد",
                LastName = "کمائی",
                UserName = "komaei@live.com",
                NormalizedUserName = "KOMAEI@LIVE.COM",
                Email = "komaei@live.com",
                NormalizedEmail = "KOMAEI@LIVE.COM",
                PasswordHash = hasher.HashPassword(null, "mK@12345")
            }
        );
    }
}