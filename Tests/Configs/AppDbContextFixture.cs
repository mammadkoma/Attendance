using Attendance.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Tests.Configs;

public class AppDbContextFixture
{
    private static readonly object _lock = new(); //2022-07-02
    private static bool _databaseInitialized;

    public AppDbContextFixture()
    {
        lock (_lock)
        {
            if (!_databaseInitialized)
            {
                using (var context = CreateContext())
                {

                }

                _databaseInitialized = true;
            }
        }
    }

    public AppDbContext CreateContext()
    {
        var config = new ConfigurationBuilder()
        .SetBasePath(AppContext.BaseDirectory)
        .AddJsonFile("appsettings.json", false, true)
        .Build();

        return new AppDbContext(
            new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(config.GetConnectionString("DataBaseConnection"))
                .Options);
    }
}
