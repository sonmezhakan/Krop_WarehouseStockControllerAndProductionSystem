﻿using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Krop.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfProductReceiptRepository : EfBaseRepository<ProductReceipt>, IProductReceiptRepository
    {
        private readonly KropContext _context;

        public EfProductReceiptRepository(KropContext context) : base(context)
        {
            _context = context;
        }

        public async Task HardDeleteAsync(ProductReceipt productReceipt)
        {
             _context.ProductReceipts.Remove(productReceipt);
        }
        
    }
}
