using CleanArch.Domain.Entity;
using CleanArch.Domain.Interface;
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
        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            return await _context.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
