﻿using Attendance.Server.Data.Entities;
using Attendance.Server.Data.EntityConfigs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Attendance.Server.Data;

public class AppDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);
        //modelBuilder.Entity<UserLogin>(entity => { entity.ToTable("UserLogin"); });
        //modelBuilder.Entity<UserToken>(entity => { entity.ToTable("UserToken"); });
    }
}