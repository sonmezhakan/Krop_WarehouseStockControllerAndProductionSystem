using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfCategoryRepository : EfBaseRepository<Category>, ICategoryRepository
    {
        private readonly KropContext _context;

        public EfCategoryRepository(KropContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllComboBoxAsync(Expression<Func<Category, bool>> predicate = null, params Expression<Func<Category, object>>[] includeProperties)
        {
            IQueryable<Category> query = _context.Categories;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            if (predicate is not null)
                query = query.Where(predicate);

            return await query.AsNoTracking().Select(x=> new Category
            {
                Id = x.Id,
                CategoryName = x.CategoryName
            }).ToListAsync();
        }
    }
}
