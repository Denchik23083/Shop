using Shop.Db.Entities;

namespace Shop.Services.AdminService
{
    public interface IAdminService
    {
        Task<Balance?> GetBalance(); 
    }
}