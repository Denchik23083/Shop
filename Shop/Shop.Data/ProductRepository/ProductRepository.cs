using Microsoft.EntityFrameworkCore;
using Shop.Db;
using Shop.Db.Entities;

namespace Shop.Data.ProductRepository
{
    public class ProductRepository(IDbContextFactory<ShopContext> factory) : IProductRepository
    {
        private readonly IDbContextFactory<ShopContext> _factory = factory;
        
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            await using var context = await _factory.CreateDbContextAsync();

            return await context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product?> GetProductAsync(ShopContext context, int productId)
        {
            return await context.Products.FirstOrDefaultAsync(_ => _.Id == productId);
        }
    }
}
