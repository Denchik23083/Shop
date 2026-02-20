using Microsoft.AspNetCore.Identity;
using Shop.Contracts.Models;
using Shop.Contracts.Utilities;
using Shop.Data.AuthRepository;
using Shop.Data.UserRepository;
using Shop.Db.Entities;

namespace Shop.Services.AuthService
{
    public class AuthService(IAuthRepository repository, 
            IUserRepository userRepository) : IAuthService
    {
        private readonly IAuthRepository _repository = repository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly PasswordHasher<User> _hasher = new();

        public async Task<bool> RegisterUserAsync(RegisterModel model)
        {
            if (model.Password != model.ConfirmPassword
                || await _repository.IsEmailRepeatAsync(model.Email))
            {
                return false;
            }

            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Role = RoleType.User,
                PasswordHash = string.Empty
            };

            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, model.Password);

            user.PasswordHash = hashedPassword;

            await _repository.RegisterUserAsync(user);

            return true;
        }

        public async Task<User?> LoginUserAsync(LoginModel model)
        {
            var user = await _userRepository.GetUserByEmailAsync(model.Email);

            if (user is null ||
                _hasher.VerifyHashedPassword(user, user.PasswordHash, model.Password)
                is PasswordVerificationResult.Failed)
            {
                return null;
            }

            return user;
        }
    }
}
