using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfEmployeeRepository : EfBaseRepository<Employee>, IEmployeeRepository
    {
        public EfEmployeeRepository(KropContext context) : base(context)
        {
        }
    }
}
