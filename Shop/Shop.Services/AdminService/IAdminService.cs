using Shop.Db.Entities;

namespace Shop.Services.AdminService
{
    public interface IAdminService
    {
        Task<Balance?> GetBalance();

        Task<bool> AddQuantityAsync(int productId, int quantity);

        Task<bool> DeleteAllQuantityAsync(int productId);
    }
}