using Shop.Db;
using Shop.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Shop.Data.UserRepository
{
    public class UserRepository(IDbContextFactory<ShopContext> factory) : IUserRepository
    {
        private readonly IDbContextFactory<ShopContext> _factory = factory;
        
        public async Task<User?> GetUserAsync(ShopContext context, int userId)
        {
            return await context.Users
                    .Include(_ => _.Order)
                    .ThenInclude(_ => _!.OrderProducts)
                    .ThenInclude(_ => _.Product)
                    .FirstOrDefaultAsync(_ => _.Id == userId);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            await using var context = await _factory.CreateDbContextAsync();

            return await context.Users.FirstOrDefaultAsync(_ => _.Email == email);
        }

        public async Task<decimal> GetMoneyAsync(int userId)
        {
            await using var context = await _factory.CreateDbContextAsync();

            var user = await context.Users.FirstOrDefaultAsync(_ => _.Id == userId);
            
            return user is null ? 0m : user.Money;
        }
    }
}
