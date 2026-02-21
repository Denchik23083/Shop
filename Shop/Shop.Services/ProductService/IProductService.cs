using Shop.Db.Entities;

namespace Shop.Services.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<Product?> GetProductAsync(int productId);

        Task<bool> AddProductToOrderAsync(int productId, int userId);

    }
}