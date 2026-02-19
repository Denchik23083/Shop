using Shop.Contracts.Models;
using Shop.Db.Entities;

namespace Shop.Services.AuthService
{
    public interface IAuthService
    {
        Task<bool> RegisterUserAsync(RegisterModel model);

        Task<User?> LoginUserAsync(LoginModel model);
    }
}