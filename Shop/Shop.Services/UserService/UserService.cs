using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shop.Contracts.Models;
using Shop.Data.UserRepository;
using Shop.Db.Entities;
using System.Security.Claims;

namespace Shop.Services.UserService
{
    public class UserService(IUserRepository repository, 
        IHttpContextAccessor http) : IUserService
    {
        private readonly IUserRepository _repository = repository;
        private readonly IHttpContextAccessor _http = http;
        private readonly PasswordHasher<User> _hasher = new();

        public async Task<bool> RegisterUserAsync(RegisterModel model)
        {
            if (model.Password != model.ConfirmPassword
                || await _repository.IsEmailRepeatAsync(model.Email))
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

        public async Task<User?> LoginUserAsync(LoginModel model)
        {
            var user = await _repository.GetUserByEmailAsync(model.Email);

            if (user is null ||
                _hasher.VerifyHashedPassword(user, user.PasswordHash, model.Password)
                is PasswordVerificationResult.Failed)
            {
                return null;
            }

            return user;
        }

        public async Task<bool> LogoutAsync()
        {
            await _http.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return true;
        }
    }
}
