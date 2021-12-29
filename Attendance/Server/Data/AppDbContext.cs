using Attendance.Server.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Attendance.Server.Data;

public class AppDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // AspNet Identity
        modelBuilder.Entity<User>(entity => { entity.ToTable("User"); });
        modelBuilder.Entity<Role>(entity => { entity.ToTable("Role"); });
        modelBuilder.Entity<UserRole>(entity => { entity.ToTable("UserRole"); });
        modelBuilder.Entity<RoleClaim>(entity => { entity.ToTable("RoleClaim"); });
        modelBuilder.Entity<UserClaim>(entity => { entity.ToTable("UserClaim"); });
        modelBuilder.Entity<UserLogin>(entity => { entity.ToTable("UserLogin"); });
        modelBuilder.Entity<UserToken>(entity => { entity.ToTable("UserToken"); });
    }
}