using Krop.DataAccess.Repositories.Abstracts.BaseRepository;
using Krop.Entities.Entities;
using System.Linq.Expressions;

namespace Krop.DataAccess.Repositories.Abstracts
{
    public interface ICategoryRepository:IBaseRepository<Category>,IBaseRepositoryAsync<Category>
    {
        Task<IEnumerable<Category>> GetAllComboBoxAsync(Expression<Func<Category, bool>> predicate = null,
            params Expression<Func<Category, object>>[] includeProperties);
    }
}
