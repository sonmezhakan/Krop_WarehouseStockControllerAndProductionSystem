using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Krop.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfProductReceiptRepository : EfBaseRepository<ProductReceipt>, IProductReceiptRepository
    {
        private readonly KropContext _context;

        public EfProductReceiptRepository(KropContext context) : base(context)
        {
            _context = context;
        }

        public async Task HardDeleteAsync(ProductReceipt productReceipt)
        {
             _context.ProductReceipts.Remove(productReceipt);
        }
        public Task<List<ProductReceipt>> GetAllWithIncludesAsync(Expression<Func<ProductReceipt, bool>> predicate = null,
            params Expression<Func<ProductReceipt, object>>[] includeProperties)
        {
            IQueryable<ProductReceipt> productReceipts = _context.ProductReceipts
                .IgnoreQueryFilters()
                .Where(p => EF.Property<DataStatu>(p, "DataStatu") != DataStatu.Deleted);

            foreach (var includeProperty in includeProperties)
            {
                productReceipts = productReceipts.Include(includeProperty);
            }
            if (predicate != null)
                productReceipts.Where(predicate);

            return productReceipts.ToListAsync();
        }

        public async Task<ProductReceipt> GetIcludesAsync(Expression<Func<ProductReceipt, bool>> predicate = null,
            params Expression<Func<ProductReceipt, object>>[] includeProperties)
        {
            IQueryable<ProductReceipt> productReceipts = _context.ProductReceipts
                .IgnoreQueryFilters()
                .Where(p => EF.Property<DataStatu>(p, "DataStatu") != DataStatu.Deleted);
            foreach (var includeProperty in includeProperties)
            {
                productReceipts = productReceipts.Include(includeProperty);
            }

            return await productReceipts.FirstOrDefaultAsync(predicate);
        }
    }
}
