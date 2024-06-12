namespace Krop.Common.Helpers.CacheHelpers
{
    public interface ICacheHelper
    {
        Task<T> GetOrAddAsync<T>(string cacheKey, Func<Task<T>> getDataFunc, int cacheDurationInMinutes);
        Task<IEnumerable<T>> GetOrAddListAsync<T>(string cacheKey, Func<Task<IEnumerable<T>>> getDataFunc, int cacheDurationInMinutes);
        Task RemoveAsync(string[] keys);

    }
}
