using Shop.Contracts.Models;

namespace Shop.Services.UserService
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(RegisterModel model);

        Task<bool> LoginUserAsync(LoginModel model);

        Task<bool> LogoutAsync();
    }
}