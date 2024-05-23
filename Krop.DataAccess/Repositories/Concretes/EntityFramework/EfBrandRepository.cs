using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfBrandRepository : EfBaseRepository<Brand>, IBrandRepository
    {
        private readonly KropContext _context;

        public EfBrandRepository(KropContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Brand>> GetAllComboBoxAsync(Expression<Func<Brand, bool>> predicate = null)
        {
            IQueryable<Brand> queries = _context.Brands;

            if(predicate is not null)
                queries = queries.Where(predicate);

            return await queries.AsNoTracking().Select(x=> new Brand { Id = x.Id,BrandName = x.BrandName }).ToListAsync();
        }
    }
}
