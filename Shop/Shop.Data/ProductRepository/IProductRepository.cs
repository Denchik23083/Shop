using Shop.Db;
using Shop.Db.Entities;

namespace Shop.Data.ProductRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<Product?> GetProductAsync(ShopContext context, int productId);
        
        Task AddProductAsync(ShopContext context, Product mappedProduct);
        
        Task DeleteProductAsync(ShopContext context, Product product);
    }
}