namespace Krop.Common.Helpers.Caching
{
    public interface ICacheService
    {
        Task<T> Get<T>(string key);
        Task<List<T>> GetList<T>(string key);
        Task<object> Get(string key);
        Task Add(string key, object value, double duration);
        Task AddList(string key, object value, double duration);
        Task<bool> IsAdd(string key);
        Task Remove(string key);
        Task ListItemRemove(string key, object value);
        Task RemoveByPattern(string pattern);
    }
}
