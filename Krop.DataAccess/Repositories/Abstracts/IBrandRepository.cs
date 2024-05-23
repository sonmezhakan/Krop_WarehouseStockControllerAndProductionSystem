using Krop.DataAccess.Repositories.Abstracts.BaseRepository;
using Krop.Entities.Entities;
using System.Linq.Expressions;

namespace Krop.DataAccess.Repositories.Abstracts
{
    public interface IBrandRepository:IBaseRepository<Brand>,IBaseRepositoryAsync<Brand>
    {
        Task<IEnumerable<Brand>> GetAllComboBoxAsync(Expression<Func<Brand, bool>> predicate = null);
    }
}
