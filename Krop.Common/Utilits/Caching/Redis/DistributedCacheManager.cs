using Newtonsoft.Json;
using StackExchange.Redis;

namespace Krop.Common.Utilits.Caching.Redis
{
    public class DistributedCacheManager : ICacheService
    {
        private readonly IDatabase _db;
        private readonly ConnectionMultiplexer _redis;

        public DistributedCacheManager()
        {
            _redis = ConnectionMultiplexer.Connect("localhost:1453");
            _db = _redis.GetDatabase();
        }

        public async Task Add(string key, object value, double duration)
        {
            var serializeValue = JsonConvert.SerializeObject(value);

            await _db.StringSetAsync(
               key,
               serializeValue,
              TimeSpan.FromMinutes(duration));
        }
        //Toplu olarak liste eklenmek istenirse.
        public async Task ListAdd<T>(string key, List<T> values, double duration)
        {
            foreach (var value in values)
            {
                var serializeValue = JsonConvert.SerializeObject(value);

                await _db.ListRightPushAsync(key, serializeValue);
            }
            TimeSpan expiration = TimeSpan.FromMinutes(duration);

            _db.KeyExpire(key, expiration);
        }
        public async Task<T> Get<T>(string key)
        {
            var value = await _db.StringGetAsync(key);
            if (value.IsNullOrEmpty)
            {
                return default;
            }

            return JsonConvert.DeserializeObject<T>(value);
        }
        public async Task<IEnumerable<T>> GetList<T>(string key)
        {
            var values = await _db.ListRangeAsync(key);
            List<T> resultList = new List<T>();
            foreach (var value in values)
            {
                resultList.Add(JsonConvert.DeserializeObject<T>(value));
            }
            return resultList;
        }

        public async Task<bool> IsAdd(string key)
        {
            return await _db.KeyExistsAsync(key);
        }

        public async Task Remove(string key)
        {
            await _db.KeyDeleteAsync(key);
        }
    }
}
