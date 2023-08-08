namespace API.Extensions.ServiceCollectionExt;

using Microsoft.EntityFrameworkCore;
using Application.Exceptions.RuntimeExceptions;
using Infrastructure.Persistance.EFCore;
using Infrastructure.Caching.Redis;

public static class ConnectionStringsRegistration
{
    public static void AddConnectionStrings(this IServiceCollection services, IConfigurationRoot config)
    {
        string? mySqlConnectionString = config.GetConnectionString("MySql");
        string? redisConnectionString = config.GetConnectionString("Redis");

        if (mySqlConnectionString == null || redisConnectionString == null)
        {
            throw new ConnectionStringException();
        }

        //EF Core
        services.AddEFCoreMySqlDbContext(mySqlConnectionString);
        //Redis
        services.AddRedis(redisConnectionString);
    }

    public static void UpdateMigrations(this IServiceCollection services)
    {
        using IServiceScope scope = services.BuildServiceProvider().CreateScope();
        SampleDbContext dbContext = scope.ServiceProvider.GetRequiredService<SampleDbContext>();
        dbContext.Database.Migrate();
    }
}
