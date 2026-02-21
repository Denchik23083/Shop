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
            return await context.Products
                .Include(_ => _.Category)
                .FirstOrDefaultAsync(_ => _.Id == productId);
        }

        public async Task AddProductAsync(ShopContext context, Product mappedProduct)
        {
            await context.Products.AddAsync(mappedProduct);
            await context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(ShopContext context, Product product)
        {
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }
    }
}
