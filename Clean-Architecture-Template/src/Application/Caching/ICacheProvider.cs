namespace Application.Caching.InterFaces;

public interface ICacheProvider
{
    Task<T> GetAsync<T>(string key);
    Task SetAsync<T>(string key, T value, TimeSpan expiration);
    Task<bool> RemoveAsync(string key);
    Task<bool> ExistsAsync(string key);
}