using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfCustomerRepository : EfBaseRepository<Customer>, ICustomerRepository
    {
        public EfCustomerRepository(KropContext context) : base(context)
        {
        }
    }
}
