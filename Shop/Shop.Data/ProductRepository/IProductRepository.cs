using Shop.Db;
using Shop.Db.Entities;

namespace Shop.Data.ProductRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<Product?> GetProductAsync(ShopContext context, int productId);
    }
}