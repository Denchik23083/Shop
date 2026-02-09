using Shop.Db;
using Shop.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Shop.Data.UserRepository
{
    public class UserRepository(ShopContext context) : IUserRepository
    {
        private readonly ShopContext _context = context;
        
        public async Task<User?> GetUserAsync(int userId)
        {
            return await _context.Users
                    .Include(_ => _.Order)
                    .ThenInclude(_ => _!.OrderProducts)
                    .ThenInclude(_ => _.Product)
                    .FirstOrDefaultAsync(_ => _.Id == userId);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(_ => _.Email == email);
        }

        public async Task<bool> IsEmailRepeatAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task RegisterUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
