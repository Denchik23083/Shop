using Shop.Db;
using Shop.Db.Entities;

namespace Shop.Data.UserRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<User?> GetUserAsync(ShopContext context, int userId);

        Task<User?> GetUserByEmailAsync(string email);

        Task<decimal> GetMoneyAsync(int userId);
    }
}