using Shop.Db.Entities;

namespace Shop.Services.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<bool> AddProductToOrderAsync(int productId, int userId);
    }
}