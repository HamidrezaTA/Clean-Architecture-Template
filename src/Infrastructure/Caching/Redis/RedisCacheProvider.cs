using Application.Caching.InterFaces;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Infrastructure.Caching.Redis;


public class RedisCacheProvider : ICacheProvider
{
    private readonly IDatabase _database;

    public RedisCacheProvider(string connectionString)
    {
        var connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);
        _database = connectionMultiplexer.GetDatabase();
    }

    public async Task<T> GetAsync<T>(string key)
    {
        var serializedData = await _database.StringGetAsync(key);
        if (!serializedData.IsNull)
        {
            return JsonConvert.DeserializeObject<T>(serializedData);
        }

        return default(T);
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
    {
        var serializedData = JsonConvert.SerializeObject(value);
        await _database.StringSetAsync(key, serializedData, expiration);
    }

    public async Task<bool> RemoveAsync(string key)
    {
        return await _database.KeyDeleteAsync(key);
    }

    public async Task<bool> ExistsAsync(string key)
    {
        return await _database.KeyExistsAsync(key);
    }
}