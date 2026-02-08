using Microsoft.EntityFrameworkCore.Storage;
using Shop.Db.Entities;

namespace Shop.Data.ProductRepository
{
    public interface IProductRepository
    {
        Task<IDbContextTransaction> BeginTransactionAsync();

        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<Product?> GetProductAsync(int productId);

        Task SaveChangesAsync();
    }
}