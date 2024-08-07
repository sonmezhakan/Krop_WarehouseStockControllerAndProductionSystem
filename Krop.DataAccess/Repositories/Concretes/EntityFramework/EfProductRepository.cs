﻿using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Krop.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Krop.DataAccess.Repositories.Concretes.EntityFramework
{
    public class EfProductRepository : EfBaseRepository<Product>, IProductRepository
    {
        private readonly KropContext _context;

        public EfProductRepository(KropContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllComboBoxAsync()
        {
            IQueryable<Product> queries = _context.Products;

            return await queries.AsNoTracking().Select(p=> new Product
            {
                Id = p.Id,
                ProductName = p.ProductName,
                ProductCode = p.ProductCode
            }).ToListAsync();
        }

        public async Task<List<Guid>> GetAllProductIdAsync()
        {
            return await _context.Products.Select(p => p.Id).ToListAsync();
        }
    }
}
