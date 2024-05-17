using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfBrandRepository : EfBaseRepository<Brand>, IBrandRepository
    {
        public EfBrandRepository(KropContext context) : base(context)
        {
        }
    }
}
