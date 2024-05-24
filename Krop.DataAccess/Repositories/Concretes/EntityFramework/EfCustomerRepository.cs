using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfCustomerRepository : EfBaseRepository<Customer>, ICustomerRepository
    {
        private readonly KropContext _context;

        public EfCustomerRepository(KropContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllComboBoxAsync()
        {
            IQueryable<Customer> queries = _context.Customers;

            return await queries.AsNoTracking().Select(c => 
            new Customer { 
                Id = c.Id, 
                Company = c.Company
            }).ToListAsync();
        }
    }
}
