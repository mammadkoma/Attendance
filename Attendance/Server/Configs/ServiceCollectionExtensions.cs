using Attendance.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasm.Server.Configs;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration configuration) =>
      services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
      // .AddTransient<IDatabaseSeeder, DatabaseSeeder>()
      ;

}