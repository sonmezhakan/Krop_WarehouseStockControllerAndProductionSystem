using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfProductionStockExitRepository : EfBaseRepository<ProductionStockExit>, IProductionStockExitRepository
    {
        public EfProductionStockExitRepository(KropContext context) : base(context)
        {
        }
    }
}
