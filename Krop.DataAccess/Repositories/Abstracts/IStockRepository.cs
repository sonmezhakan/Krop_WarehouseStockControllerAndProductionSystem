using Krop.DataAccess.Repositories.Abstracts.BaseRepository;
using Krop.Entities.Entities;
using System.Linq.Expressions;

namespace Krop.DataAccess.Repositories.Abstracts
{
    public interface IStockRepository : IBaseRepository<Stock>, IBaseRepositoryAsync<Stock>
    {
        Task<IEnumerable<Stock>> GetAllStockAsync(Expression<Func<Stock, bool>> predicate = null,
             params Expression<Func<Stock, object>>[] includeProperties);
    }
}
