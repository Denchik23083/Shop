using Microsoft.EntityFrameworkCore;
using Shop.Db;
using Shop.Db.Entities;

namespace Shop.Services
{
    public class ProductService(ShopContext context) : IProductService
    {
        private readonly ShopContext _context = context;

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
