using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Krop.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfStockInputRepository : EfBaseRepository<StockInput>, IStockInputRepository
    {
        private readonly KropContext _context;

        public EfStockInputRepository(KropContext context) : base(context)
        {
            _context = context;
        }
        
    }
}
