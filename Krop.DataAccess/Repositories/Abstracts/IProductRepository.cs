using Krop.DataAccess.Repositories.Abstracts.BaseRepository;
using Krop.Entities.Entities;
using System.Linq.Expressions;

namespace Krop.DataAccess.Repositories.Abstracts
{
    public interface IProductRepository : IBaseRepository<Product>, IBaseRepositoryAsync<Product>
    {
        Task<List<Guid>> GetAllProductIdAsync();
        Task<List<Product>> GetAllComboBoxAsync();
        Task<List<Product>> GetAllWithIncludesAsync(Expression<Func<Product, bool>> predicate = null, 
            params Expression<Func<Product, object>>[] includeProperties);
        Task<Product> GetIcludesAsync(Expression<Func<Product, bool>> predicate = null, 
            params Expression<Func<Product, object>>[] includeProperties);
    }
}
