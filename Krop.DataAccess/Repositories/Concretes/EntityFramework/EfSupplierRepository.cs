using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfSupplierRepository : EfBaseRepository<Supplier>, ISupplierRepository
    {
        private readonly KropContext _context;

        public EfSupplierRepository(KropContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> GetAllComboBoxAsync()
        {
            IQueryable<Supplier> queries = _context.Suppliers;

            return await queries.AsNoTracking().Select(x => new Supplier
            {
                Id = x.Id,
                Company = x.Company
            }).ToListAsync();
        }
    }
}
