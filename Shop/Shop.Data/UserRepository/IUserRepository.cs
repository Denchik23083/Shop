using Shop.Db.Entities;

namespace Shop.Data.UserRepository
{
    public interface IUserRepository
    {
        Task<User?> GetUser(int userId);

        Task RegisterUserAsync(User user);
    }
}