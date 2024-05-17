using Krop.Entities.Entities;
using Krop.Entities.Interfaces;
using System.Linq.Expressions;

namespace Krop.DataAccess.Repositories.Abstracts.BaseRepository
{
    public interface IBaseRepository<T> where T : class, IEntity<Guid>, new()
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null,
            params Expression<Func<T, object>>[] includeProperties);
        T Get(Expression<Func<T,bool>> predicate = null);
        T Find(Guid id);
        bool Any(Expression<Func<T,bool>> predicate = null);

        bool Add(T entity);
        bool AddRange(List<T> entities);

        bool Update(T entity);
        bool UpdateRange(List<T> entities);

        bool Delete(T entity);
        bool DeleteRange(List<T> entities);
    }
}
