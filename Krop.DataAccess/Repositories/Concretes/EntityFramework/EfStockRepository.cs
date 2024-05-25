using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfStockRepository : EfBaseRepository<Stock>, IStockRepository
    {
        private readonly KropContext _context;

        public EfStockRepository(KropContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stock>> GetAllStockAsync(Expression<Func<Stock, bool>> predicate = null, params Expression<Func<Stock, object>>[] includeProperties)
        {
            IQueryable<Stock> queries = _context.Stocks;
            foreach (var includeProperty in includeProperties)
            {
                queries = queries.Include(includeProperty);
            }

            if (predicate is null)
                return await queries.ToListAsync();

            return await queries.Where(predicate).ToListAsync();
        }

    }
}
