using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfProductNotificationRepository : EfBaseRepository<ProductNotification>, IProductNotificationRepository
    {
        public EfProductNotificationRepository(KropContext context) : base(context)
        {
        }
    }
}
