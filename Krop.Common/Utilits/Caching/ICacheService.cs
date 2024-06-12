namespace Krop.Common.Utilits.Caching
{
    public interface ICacheService
    {
        Task<T> Get<T>(string key);
        Task<IEnumerable<T>> GetList<T>(string key);
        Task Add(string key, object value, double duration);
        Task ListAdd<T>(string key, List<T> values, double duration);
        Task<bool> IsAdd(string key);
        Task Remove(string key);
    }
}
