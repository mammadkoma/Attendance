using Attendance.Server.Data;
using Attendance.Server.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Attendance.Server.Configs;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => { options.UseSqlServer(configuration.GetConnectionString("DataBaseConnection")); });
        return services;
    }

    internal static IServiceCollection AddIdentityAndOptions(this IServiceCollection services)
    {
        services.AddIdentity<User, Role>(op =>
        {
            op.ClaimsIdentity.UserNameClaimType = "UserName";
            op.ClaimsIdentity.RoleClaimType = "roles";
        }
            ).AddRoles<Role>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

        //services.AddIdentity<User, Role>()
        //.AddEntityFrameworkStores<AppDbContext>()
        //.AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            options.ClaimsIdentity.UserNameClaimType = "UserName";
            options.ClaimsIdentity.RoleClaimType = "roles";

            // Password settings
            options.Password.RequiredLength = 6;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;

            // Lockout settings.
            //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //options.Lockout.MaxFailedAccessAttempts = 5;
            //options.Lockout.AllowedForNewUsers = true;
        });
        return services;
    }

    public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        //JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters.RoleClaimType = "roles";
            options.TokenValidationParameters.NameClaimType = "UserName";

            options.TokenValidationParameters = new TokenValidationParameters
            {
                NameClaimType = "UserName",
                RoleClaimType = "roles",

                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = jwtSettings["validIssuer"],
                ValidAudience = jwtSettings["validAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["securityKey"]))
            };
        });
    }
}