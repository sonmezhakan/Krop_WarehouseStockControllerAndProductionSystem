using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfStockTransferRepostiory : EfBaseRepository<StockTransfer>, IStockTransferRepository
    {
        public EfStockTransferRepostiory(KropContext context) : base(context)
        {
        }
    }
}
