using Shop.Contracts.Models;
using Shop.Db.Entities;

namespace Shop.Services.UserService
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(RegisterModel model);

        Task<User?> LoginUserAsync(LoginModel model);

        Task<decimal> GetMoneyAsync(int userId);
    }
}