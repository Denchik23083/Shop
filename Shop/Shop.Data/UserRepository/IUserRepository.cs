using Shop.Db;
using Shop.Db.Entities;

namespace Shop.Data.UserRepository
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(ShopContext context, int userId);

        Task<User?> GetUserByEmailAsync(string email);

        Task<decimal> GetMoneyAsync(int userId);

        Task<bool> IsEmailRepeatAsync(string email);

        Task RegisterUserAsync(User user);
    }
}