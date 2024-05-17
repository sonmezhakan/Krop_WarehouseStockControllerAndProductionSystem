using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EFBranchRepository : EfBaseRepository<Branch>, IBranchRepository
    {
        private readonly KropContext _context;

        public EFBranchRepository(KropContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Guid>> GetAllBranchIdAsync()
        {
           return  await _context.Branches.Select(b => b.Id).ToListAsync();
        }
    }
}
