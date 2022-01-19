using Attendance.Server.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Server.Data;

public class AppDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IUnitOfWork
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }

    public void MarkAsDeleted<TEntity>(TEntity entity) => base.Entry(entity).State = EntityState.Deleted;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // AspNet Identity
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");
            entity.Property(p => p.FirstName).HasMaxLength(50);
            entity.Property(p => p.LastName).HasMaxLength(50);
            entity.Property(p => p.UserName).IsUnicode(false).HasMaxLength(50).IsRequired();
            entity.Property(p => p.NormalizedUserName).IsUnicode(false).HasMaxLength(50).IsRequired();
            entity.Property(p => p.Email).IsUnicode(false).HasMaxLength(50).IsRequired();
            entity.Property(p => p.NormalizedEmail).IsUnicode(false).HasMaxLength(50).IsRequired();
            entity.Property(p => p.PasswordHash).IsUnicode(false).IsRequired();
            entity.Property(p => p.SecurityStamp).IsUnicode(false);
            entity.Property(p => p.ConcurrencyStamp).IsUnicode(false);
            entity.Property(p => p.PhoneNumber).HasColumnName("Mobile").IsUnicode(false).HasMaxLength(11).IsFixedLength(true);
        });
        modelBuilder.Entity<Role>(entity => { entity.ToTable("Role"); });
        modelBuilder.Entity<UserRole>(entity => { entity.ToTable("UserRole"); });
        modelBuilder.Entity<RoleClaim>(entity => { entity.ToTable("RoleClaim"); });
        modelBuilder.Entity<UserClaim>(entity => { entity.ToTable("UserClaim"); });
        modelBuilder.Entity<UserLogin>(entity => { entity.ToTable("UserLogin"); });
        modelBuilder.Entity<UserToken>(entity => { entity.ToTable("UserToken"); });
    }
}