using Krop.Common.Helpers.Caching;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Krop.Common.Helpers.Caching.Redis
{
    public class DistributedCacheManager : ICacheService
    {
        private readonly IDatabase _db;
        private readonly ConnectionMultiplexer _redis;
        private readonly JsonSerializerSettings _serializerSettings;

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
        public async Task AddList(string key, object value, double duration)
        {
            var serializeValue = JsonConvert.SerializeObject(value);

            await _db.ListRightPushAsync(key, serializeValue);

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
        public async Task<List<T>> GetList<T>(string key)
        {
            var values = await _db.ListRangeAsync(key);
            if (values is null || values.Length <= 0)
            {
                return null;
            }
            List<T> resultList = new List<T>();
            foreach (var value in values)
            {
                resultList.Add(JsonConvert.DeserializeObject<T>(value));
            }
            return resultList;
        }

        public async Task<object> Get(string key)
        {
            var value = await _db.StringGetAsync(key);
            if (value.IsNullOrEmpty)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<object>(value, _serializerSettings);
        }

        public async Task<bool> IsAdd(string key)
        {
            return await _db.KeyExistsAsync(key);
        }

        public async Task Remove(string key)
        {
            await _db.KeyDeleteAsync(key);
        }
        public async Task ListItemRemove(string key, object value)
        {
            var serializeValue = JsonConvert.SerializeObject(value);
            await _db.ListRemoveAsync(key, serializeValue);
        }

        public async Task RemoveByPattern(string pattern)
        {
            string[] keys = pattern.Split(',');
            foreach (var key in keys)
            {
                await _db.KeyDeleteAsync(key);
            }
        }
    }
}
