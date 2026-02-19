using Microsoft.EntityFrameworkCore;
using Shop.Db;
using Shop.Db.Entities;

namespace Shop.Data.AuthRepository
{
    public class AuthRepository(IDbContextFactory<ShopContext> factory) : IAuthRepository
    {
        private readonly IDbContextFactory<ShopContext> _factory = factory;

        public async Task RegisterUserAsync(User user)
        {
            await using var context = await _factory.CreateDbContextAsync();

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task<bool> IsEmailRepeatAsync(string email)
        {
            await using var context = await _factory.CreateDbContextAsync();

            return await context.Users.AnyAsync(u => u.Email == email);
        }
    }
}
