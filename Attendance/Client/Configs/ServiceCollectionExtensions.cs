namespace Attendance.Client.Configs;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPolicies(this IServiceCollection services)
    {
        services.AddAuthorizationCore(config =>
        {
            config.AddPolicy("admin", policy => policy.RequireClaim("Roles", "admin"));
            config.AddPolicy("user", policy => policy.RequireClaim("Roles", "user"));
        });

        return services;
    }
}