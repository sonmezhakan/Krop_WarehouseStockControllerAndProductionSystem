using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EFProductReceiptRepository : EfBaseRepository<ProductReceipt>, IProductReceiptRepository
    {
        private readonly KropContext _context;

        public EFProductReceiptRepository(KropContext context) : base(context)
        {
            _context = context;
        }

        public async Task HardDeleteAsync(ProductReceipt productReceipt)
        {
             _context.ProductReceipts.Remove(productReceipt);
            _context.SaveChangesAsync();
        }
    }
}
