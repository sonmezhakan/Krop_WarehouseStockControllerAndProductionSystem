using Krop.DataAccess.Repositories.Abstracts.BaseRepository;
using Krop.Entities.Entities;

namespace Krop.DataAccess.Repositories.Abstracts
{
    public interface IProductRepository : IBaseRepository<Product>, IBaseRepositoryAsync<Product>
    {
        Task<List<Guid>> GetAllProductIdAsync();
    }
}
