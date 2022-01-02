using Attendance.Server.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Server.Configs;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration configuration) =>
      services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
      // .AddTransient<IDatabaseSeeder, DatabaseSeeder>()
      ;

    internal static IServiceCollection AddIdentityOptions(this IServiceCollection services)
    {
        services.Configure<IdentityOptions>(options =>
        {
            // User settings.
            options.User.AllowedUserNameCharacters = null;

            // Password settings.
            //options.Password.RequireDigit = true;
            //options.Password.RequireLowercase = true;
            //options.Password.RequireNonAlphanumeric = true;
            //options.Password.RequireUppercase = true;
            //options.Password.RequiredLength = 6;
            //options.Password.RequiredUniqueChars = 1;

            // Lockout settings.
            //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //options.Lockout.MaxFailedAccessAttempts = 5;
            //options.Lockout.AllowedForNewUsers = true;
        });
        return services;
    }
}