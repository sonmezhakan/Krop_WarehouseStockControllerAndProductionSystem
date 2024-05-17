using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfProductRepository : EfBaseRepository<Product>, IProductRepository
    {
        private readonly KropContext _context;

        public EfProductRepository(KropContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Guid>> GetAllProductIdAsync()
        {
            return await _context.Products.Select(p => p.Id).ToListAsync();
        }
    }
}
