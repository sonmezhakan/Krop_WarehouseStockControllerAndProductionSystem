using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfDepartmentRepository : EfBaseRepository<Department>, IDepartmentRepository
    {
        private readonly KropContext _context;

        public EfDepartmentRepository(KropContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllComboBoxAsync()
        {
            IQueryable<Department> queries = _context.Departments;

            return await queries.AsNoTracking().Select(d => new Department
            {
                Id = d.Id,
                DepartmentName = d.DepartmentName
            }).ToListAsync();
        }
    }
}
