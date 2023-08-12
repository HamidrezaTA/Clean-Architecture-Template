namespace Infrastructure.Persistance.EFCore;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class EFCoreRegistration
{
    public static void AddEFCoreMySqlDbContext(this IServiceCollection services, string connectionString, int timeout = 30)
    {
        services.AddDbContext<SampleDbContext>(options =>
        {
            options
                .UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString),
                    options =>
                    {
                        options.EnableRetryOnFailure();
                        options.CommandTimeout(timeout);
                    }
                ).UseSnakeCaseNamingConvention();
        });
    }
}
