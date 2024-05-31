using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfStockInputRepository : EfBaseRepository<StockInput>, IStockInputRepository
    {
        public EfStockInputRepository(KropContext context) : base(context)
        {
        }
    }
}
