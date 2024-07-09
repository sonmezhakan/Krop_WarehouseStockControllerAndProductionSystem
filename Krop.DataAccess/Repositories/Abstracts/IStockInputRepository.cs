using Krop.DataAccess.Repositories.Abstracts.BaseRepository;
using Krop.Entities.Entities;
using System.Linq.Expressions;

namespace Krop.DataAccess.Repositories.Abstracts
{
    public interface IStockInputRepository:IBaseRepository<StockInput>,IBaseRepositoryAsync<StockInput>
    {
        Task<List<StockInput>> GetAllWithIncludesAsync(Expression<Func<StockInput, bool>> predicate = null,
            params Expression<Func<StockInput, object>>[] includeProperties);
        Task<StockInput> GetIcludesAsync(Expression<Func<StockInput, bool>> predicate = null,
            params Expression<Func<StockInput, object>>[] includeProperties);
    }
}
