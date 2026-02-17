using Microsoft.EntityFrameworkCore;
using Shop.Db;
using Shop.Db.Entities;

namespace Shop.Data.AdminRepository
{
    public class AdminRepository : IAdminRepository
    {
        public async Task<Balance?> GetBalance(ShopContext context)
        {
            return await context.Balances.SingleAsync();
        }
    }
}
