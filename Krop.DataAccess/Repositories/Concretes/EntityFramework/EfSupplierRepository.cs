using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.Repositories.Abstracts.BaseRepository;
using Krop.Entities.Entities;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfSupplierRepository : EfBaseRepository<Supplier>, ISupplierRepository
    {
        public EfSupplierRepository(KropContext context) : base(context)
        {
        }
    }
}
