
using Shop.Contracts.Utilities;
using Shop.Data.DbContextScopeFactory;
using Shop.Data.UserRepository;
using Shop.Db.Entities;

namespace Shop.Services.GodService
{
    public class GodService(IUserRepository userRepository,
            IDbContextScopeFactory dbContextScopeFactory) : IGodService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IDbContextScopeFactory _dbContextScopeFactory = dbContextScopeFactory;

        public async Task<bool> UserToAdminAsync(int userId)
        {
            using var context = await dbContextScopeFactory.GetSingleDbContextAsync();

            var user = await _userRepository.GetUserByRoleAsync(context, userId, RoleType.User);

            if (user is null)
            {
                return false;
            }

            user.Role = RoleType.Admin;

            await _dbContextScopeFactory.SaveChangesAsync(context);

            return true;
        }

        public async Task<bool> AdminToUserAsync(int adminId)
        {
            using var context = await dbContextScopeFactory.GetSingleDbContextAsync();

            var admin = await _userRepository.GetUserByRoleAsync(context, adminId, RoleType.Admin);

            if (admin is null)
            {
                return false;
            }

            admin.Role = RoleType.User;

            await _dbContextScopeFactory.SaveChangesAsync(context);

            return true;
        }
    }
}
