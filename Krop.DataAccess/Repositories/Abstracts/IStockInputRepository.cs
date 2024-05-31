using Krop.DataAccess.Repositories.Abstracts.BaseRepository;
using Krop.Entities.Entities;

namespace Krop.DataAccess.Repositories.Abstracts
{
    public interface IStockInputRepository:IBaseRepository<StockInput>,IBaseRepositoryAsync<StockInput>
    {
    }
}
