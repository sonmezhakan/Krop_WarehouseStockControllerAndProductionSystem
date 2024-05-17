using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfStockRepository : EfBaseRepository<Stock>, IStockRepository
    {
        private readonly KropContext _context;

        public EfStockRepository(KropContext context) : base(context)
        {
            _context = context;
        }

    }
}
