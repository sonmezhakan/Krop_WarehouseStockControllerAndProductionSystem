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

        void Add(T entity);
        void AddRange(List<T> entities);

        void Update(T entity);
        void UpdateRange(List<T> entities);

        void Delete(T entity);
        void DeleteRange(List<T> entities);
    }
}
