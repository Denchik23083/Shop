using Microsoft.AspNetCore.Identity;
using Shop.Contracts.Models;
using Shop.Data.UserRepository;
using Shop.Db.Entities;

namespace Shop.Services.UserService
{
    public class UserService(IUserRepository repository) : IUserService
    {
        private readonly IUserRepository _repository = repository;

        public async Task<bool> RegisterUserAsync(RegisterModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return false;
            }

            var user = new User();

            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, model.Password);

            user.Name = model.Name;
            user.Email = model.Email;
            user.PasswordHash = hashedPassword;
            user.Money = 10000.00m;

            await _repository.RegisterUserAsync(user);

            return true;
        }
    }
}
