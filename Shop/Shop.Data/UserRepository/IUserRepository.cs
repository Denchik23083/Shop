using Shop.Db.Entities;

namespace Shop.Data.UserRepository
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(int userId);

        Task<User?> GetUserByEmailAsync(string email);

        Task<bool> IsEmailRepeatAsync(string email);

        Task RegisterUserAsync(User user);
    }
}