using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Krop.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfEmployeeRepository : EfBaseRepository<Employee>, IEmployeeRepository
    {
        private readonly KropContext _context;

        public EfEmployeeRepository(KropContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<Employee>> GetAllWithIncludesAsync(Expression<Func<Employee, bool>> predicate = null,
            params Expression<Func<Employee, object>>[] includeProperties)
        {
            IQueryable<Employee> employees = _context.Employees
                .IgnoreQueryFilters()
                .Where(p => EF.Property<DataStatu>(p, "DataStatu") != DataStatu.Deleted);

            foreach (var includeProperty in includeProperties)
            {
                employees = employees.Include(includeProperty);
            }
            if (predicate != null)
                employees.Where(predicate);

            return employees.ToListAsync();
        }
        public async Task<Employee> GetIcludesAsync(Expression<Func<Employee, bool>> predicate = null,
            params Expression<Func<Employee, object>>[] includeProperties)
        {
            IQueryable<Employee> employees = _context.Employees
                .IgnoreQueryFilters()
                .Where(p => EF.Property<DataStatu>(p, "DataStatu") != DataStatu.Deleted);
            foreach (var includeProperty in includeProperties)
            {
                employees = employees.Include(includeProperty);
            }

            return await employees.FirstOrDefaultAsync(predicate);
        }
        public async Task<IEnumerable<Employee>> GetAllComboBoxAsync()
        {
            IQueryable<Employee> queries = _context.Employees.IgnoreQueryFilters().Where(x=>x.AppUserId == x.AppUser.Id && EF.Property<DataStatu>(x,"DataStatu") != DataStatu.Deleted)
                .Include(e => e.AppUser);

            return await queries.AsNoTracking().Select(x => new Employee
            {
                AppUserId = x.AppUserId,
                AppUser = new AppUser
                {
                    UserName = x.AppUser.UserName
                }
            }).ToListAsync();
        }
    }
}
