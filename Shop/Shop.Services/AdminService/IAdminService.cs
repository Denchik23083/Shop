using Shop.Contracts.Models;
using Shop.Db.Entities;

namespace Shop.Services.AdminService
{
    public interface IAdminService
    {
        Task<Balance?> GetBalance();
        
        Task<bool> AddQuantityAsync(int productId, int buyQuantity, int dayExpired);

        Task<bool> PurchaseQuantityAsync(int productId, int purchaseQuantity);
        
        Task<bool> UpdateProductAsync(ProductEditModel productEditModel, int productId);

        Task<bool> DeleteAllQuantityAsync(int productId);

        Task<bool> DeleteProductAsync(int productId);

        Task<bool> DeleteUserAsync(int userId);
    }
}