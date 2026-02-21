using Shop.Contracts.Utilities;
using Shop.Db.Entities;

namespace Shop.Services.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersByRoleAsync(RoleType role);

        Task<User?> GetUserAsync(int userId);
        
        Task<decimal> GetMoneyAsync(int userId);
    }
}