using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfDepartmentRepository : EfBaseRepository<Department>, IDepartmentRepository
    {
        public EfDepartmentRepository(KropContext context) : base(context)
        {
        }
    }
}
