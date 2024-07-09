using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Krop.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfStockInputRepository : EfBaseRepository<StockInput>, IStockInputRepository
    {
        private readonly KropContext _context;

        public EfStockInputRepository(KropContext context) : base(context)
        {
            _context = context;
        }
        public Task<List<StockInput>> GetAllWithIncludesAsync(Expression<Func<StockInput, bool>> predicate = null,
            params Expression<Func<StockInput, object>>[] includeProperties)
        {
            IQueryable<StockInput> stockInputs = _context.StockInputs
                .IgnoreQueryFilters()
                .Where(p => EF.Property<DataStatu>(p, "DataStatu") != DataStatu.Deleted);

            foreach (var includeProperty in includeProperties)
            {
                stockInputs = stockInputs.Include(includeProperty);
            }
            if (predicate != null)
                stockInputs.Where(predicate);

            return stockInputs.ToListAsync();
        }

        public async Task<StockInput> GetIcludesAsync(Expression<Func<StockInput, bool>> predicate = null,
            params Expression<Func<StockInput, object>>[] includeProperties)
        {
            IQueryable<StockInput> stockInputs = _context.StockInputs
                .IgnoreQueryFilters()
                .Where(p => EF.Property<DataStatu>(p, "DataStatu") != DataStatu.Deleted);
            foreach (var includeProperty in includeProperties)
            {
                stockInputs = stockInputs.Include(includeProperty);
            }

            return await stockInputs.FirstOrDefaultAsync(predicate);
        }
    }
}
