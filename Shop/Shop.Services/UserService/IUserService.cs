using Shop.Contracts.Models;

namespace Shop.Services.UserService
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(RegisterModel model);
    }
}