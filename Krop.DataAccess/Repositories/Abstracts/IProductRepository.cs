using Krop.DataAccess.Repositories.Abstracts.BaseRepository;
using Krop.Entities.Entities;
using System.Linq.Expressions;

namespace Krop.DataAccess.Repositories.Abstracts
{
    public interface IProductRepository : IBaseRepository<Product>, IBaseRepositoryAsync<Product>
    {
        Task<List<Guid>> GetAllProductIdAsync();
        Task<List<Product>> GetAllComboBoxAsync();
    }
}
