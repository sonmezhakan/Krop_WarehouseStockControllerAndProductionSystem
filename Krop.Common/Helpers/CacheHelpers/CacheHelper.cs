using Krop.Common.Utilits.Caching;

namespace Krop.Common.Helpers.CacheHelpers
{
    public class CacheHelper:ICacheHelper
    {
        private readonly ICacheService _cacheService;

        public CacheHelper(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<T> GetOrAddAsync<T>(string cacheKey, Func<Task<T>> getDataFunc, int cacheDurationInMinutes)
        {
            if(await _cacheService.IsAdd(cacheKey))
            {
               return await _cacheService.Get<T>(cacheKey);
            }
            else
            {
                var data = await getDataFunc();
                await _cacheService.Add(cacheKey, data, cacheDurationInMinutes);
                return data;
            }  
        }

        public async Task<IEnumerable<T>> GetOrAddListAsync<T>(string cacheKey, Func<Task<IEnumerable<T>>> getDataFunc, int cacheDurationInMinutes)
        {
            if(await _cacheService.IsAdd(cacheKey))
            {
                return await _cacheService.GetList<T>(cacheKey);
            }
            else
            {
                var data = await getDataFunc();
                if (data.Any())
                {
                    await _cacheService.ListAdd(cacheKey, data.ToList(), cacheDurationInMinutes);
                }
                return data;
            }
        }
        public async Task RemoveAsync(string[] keys)
        {
            foreach (var key in keys)
            {
                if (await _cacheService.IsAdd(key))
                    await _cacheService.Remove(key);
            }
        }
    }
}
