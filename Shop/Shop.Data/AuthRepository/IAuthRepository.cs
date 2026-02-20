using Shop.Db.Entities;

namespace Shop.Data.AuthRepository
{
    public interface IAuthRepository
    {
        Task RegisterUserAsync(User user);

        Task<bool> IsEmailRepeatAsync(string email);
    }
}