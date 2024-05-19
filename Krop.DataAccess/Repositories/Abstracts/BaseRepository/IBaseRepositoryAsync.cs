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

        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);

        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(List<T> entities);

        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(List<T> entities);

    }
}
