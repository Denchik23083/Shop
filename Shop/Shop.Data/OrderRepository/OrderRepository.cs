using Microsoft.EntityFrameworkCore;
using Shop.Db;
using Shop.Db.Entities;

namespace Shop.Data.OrderRepository
{
    public class OrderRepository(IDbContextFactory<ShopContext> factory) : IOrderRepository
    {
        private readonly IDbContextFactory<ShopContext> _factory = factory;

        public async Task<Order?> GetOrderAsync(int userId)
        {
            await using var context = await _factory.CreateDbContextAsync();

            return await context.Orders
                .Include(_ => _.OrderProducts)
                .ThenInclude(_ => _.Product)
                .ThenInclude(_ => _!.Category)
                .FirstOrDefaultAsync(_ => _.UserId == userId);
        }

        public async Task<OrderProduct?> GetOrderProductAsync(ShopContext context, int productId, int orderId)
        {
            return await context.OrderProducts
                .Include(_ => _.Product)
                .FirstOrDefaultAsync(_ => _.ProductId == productId
                    && _.OrderId == orderId);
        }

        public async Task AddOrderAsync(ShopContext context, Order order)
        {
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
        }

        public async Task RemoveOrderAsync(ShopContext context, Order order)
        {
            context.Orders.Remove(order);
            await context.SaveChangesAsync();
        }

        public async Task RemoveProductFromOrderAsync(ShopContext context, OrderProduct orderProduct)
        {
            context.OrderProducts.Remove(orderProduct);
            await context.SaveChangesAsync();
        }
    }
}
