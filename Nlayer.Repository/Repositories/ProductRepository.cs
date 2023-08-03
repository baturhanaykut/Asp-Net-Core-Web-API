using Microsoft.EntityFrameworkCore;
using Nlayer.Core.Entities;
using Nlayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            //Eager Loding yaptık.
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
