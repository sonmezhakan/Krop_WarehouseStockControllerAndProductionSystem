
using Krop.DataAccess.Context;

namespace Krop.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KropContext _kropContext;

        public UnitOfWork(KropContext kropContext)
        {
            _kropContext = kropContext;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _kropContext.SaveChangesAsync();
        }
    }
}
