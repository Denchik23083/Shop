using Microsoft.EntityFrameworkCore;
using Shop.Db;
using Shop.Db.Entities;

namespace Shop.Services.OrderService
{
    public class OrderService(ShopContext context) : IOrderService
    {
        private readonly ShopContext _context = context;

        public async Task<Order?> GetOrder(int userId)
        {
            return await _context.Orders
                .Include(_ => _.OrderProducts)
                .ThenInclude(_ => _.Product)
                .ThenInclude(_ => _!.Category)
                .FirstOrDefaultAsync(_ => _.UserId == userId);
        }
    }
}
