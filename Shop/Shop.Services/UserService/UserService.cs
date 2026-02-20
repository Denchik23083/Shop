using Shop.Contracts.Utilities;
using Shop.Data.DbContextScopeFactory;
using Shop.Data.UserRepository;
using Shop.Db.Entities;

namespace Shop.Services.UserService
{
    public class UserService(IUserRepository repository,
            IDbContextScopeFactory dbContextScopeFactory) : IUserService
    {
        private readonly IUserRepository _repository = repository;
        private readonly IDbContextScopeFactory _dbContextScopeFactory = dbContextScopeFactory;
        
        public async Task<IEnumerable<User>> GetAllUsersByRoleAsync(RoleType role)
        {
            return await _repository.GetAllUsersByRoleAsync(role);
        }

        public async Task<User?> GetUserAsync(int userId)
        {
            await using var context = await _dbContextScopeFactory.GetSingleDbContextAsync();

            return await _repository.GetUserAsync(context, userId);
        }
        
        public async Task<decimal> GetMoneyAsync(int userId)
        {
            return await _repository.GetMoneyAsync(userId);
        }
    }
}
