using Shop.Db.Entities;

namespace Shop.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
    }
}