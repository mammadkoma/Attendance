using Attendance.Server.Data.Entities;
using Attendance.Server.Data.EntityConfigs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Attendance.Server.Data;

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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);
        //modelBuilder.Entity<RoleClaim>(entity => { entity.ToTable("RoleClaim"); });
        //modelBuilder.Entity<UserClaim>(entity => { entity.ToTable("UserClaim"); });
        //modelBuilder.Entity<UserLogin>(entity => { entity.ToTable("UserLogin"); });
        //modelBuilder.Entity<UserToken>(entity => { entity.ToTable("UserToken"); });
    }
}