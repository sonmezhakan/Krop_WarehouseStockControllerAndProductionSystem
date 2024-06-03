using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfProductionRepository : EfBaseRepository<Production>, IProductionRepository
    {
        public EfProductionRepository(KropContext context) : base(context)
        {
        }
    }
}
