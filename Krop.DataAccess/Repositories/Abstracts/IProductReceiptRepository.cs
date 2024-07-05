using Krop.DataAccess.Repositories.Abstracts.BaseRepository;
using Krop.Entities.Entities;
using System.Linq.Expressions;

namespace Krop.DataAccess.Repositories.Abstracts
{
    public interface IProductReceiptRepository:IBaseRepository<ProductReceipt>,IBaseRepositoryAsync<ProductReceipt>
    {
        Task HardDeleteAsync(ProductReceipt productReceipt);
        Task<List<ProductReceipt>> GetAllWithIncludesAsync(Expression<Func<ProductReceipt, bool>> predicate = null,
            params Expression<Func<ProductReceipt, object>>[] includeProperties);
        Task<ProductReceipt> GetIcludesAsync(Expression<Func<ProductReceipt, bool>> predicate = null,
            params Expression<Func<ProductReceipt, object>>[] includeProperties);
    }
}
