using Shop.Contracts.Models;
using Shop.Db.Entities;

namespace Shop.Services.UserService
{
    public interface IUserService
    {
        Task<User?> GetUserAsync(int userId);
        
        Task<decimal> GetMoneyAsync(int userId);
    }
}