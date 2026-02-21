using Shop.Contracts.Utilities;
using Shop.Db;
using Shop.Db.Entities;

namespace Shop.Data.UserRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersByRoleAsync(RoleType role);

        Task<User?> GetUserAsync(ShopContext context, int userId);

        Task<User?> GetUserByEmailAsync(string email);

        Task<User?> GetUserByRoleAsync(ShopContext context, int userId, RoleType role);

        Task<decimal> GetMoneyAsync(int userId);

        Task DeleteUserAsync(ShopContext context, User user);
    }
}