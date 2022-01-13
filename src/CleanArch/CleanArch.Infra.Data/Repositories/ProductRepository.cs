using CleanArch.Domain.Entity;
using CleanArch.Domain.Interface;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public override async Task<Product> GetByIdAsync(int? id)
        {
            return await _context.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
