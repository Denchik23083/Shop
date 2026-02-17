using Shop.Db;
using Shop.Db.Entities;

namespace Shop.Data.AdminRepository
{
    public interface IAdminRepository
    {
        Task<Balance?> GetBalance(ShopContext context);
    }
}