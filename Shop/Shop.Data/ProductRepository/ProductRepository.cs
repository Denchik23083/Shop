using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Shop.Db;
using Shop.Db.Entities;

namespace Shop.Data.ProductRepository
{
    public class ProductRepository(ShopContext context) : IProductRepository
    {
        private readonly ShopContext _context = context;

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product?> GetProductAsync(int productId)
        {
            return await _context.Products.FirstOrDefaultAsync(_ => _.Id == productId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
