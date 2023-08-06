using Application.Caching.InterFaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Caching.Redis;

public static class RedisRegistration
{
    public static void AddRedis(this IServiceCollection services, string redisConnectionString)
    {
        services.AddSingleton<ICacheProvider>(sp => new RedisCacheProvider(redisConnectionString));
    }
}