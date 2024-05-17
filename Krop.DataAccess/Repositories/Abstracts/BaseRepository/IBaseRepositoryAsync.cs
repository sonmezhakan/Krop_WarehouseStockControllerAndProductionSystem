using Krop.Entities.Interfaces;
using System.Linq.Expressions;

namespace Krop.DataAccess.Repositories.Abstracts.BaseRepository
{
    public interface IBaseRepositoryAsync<T> where T : class, IEntity<Guid>, new()
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
            params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate = null);
        Task<T> FindAsync(Guid id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate = null);

        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);

        Task<bool> UpdateAsync(T entity);
        Task<bool> UpdateRangeAsync(List<T> entities);

        Task<bool> DeleteAsync(T entity);
        Task<bool> DeleteRangeAsync(List<T> entities);

    }
}
