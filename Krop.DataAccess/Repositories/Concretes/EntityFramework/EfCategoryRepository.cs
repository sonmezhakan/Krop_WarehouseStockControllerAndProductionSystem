using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfCategoryRepository : EfBaseRepository<Category>, ICategoryRepository
    {
        public EfCategoryRepository(KropContext context) : base(context)
        {
        }
    }
}
