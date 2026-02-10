using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Shop.Db;
using Shop.Db.Entities;

namespace Shop.Data.OrderRepository
{
    public class OrderRepository(IDbContextFactory<ShopContext> factory) : IOrderRepository
    {
        private readonly IDbContextFactory<ShopContext> _factory = factory;

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            await using var context = await _factory.CreateDbContextAsync();

            return await context.Database.BeginTransactionAsync();
        }

        public async Task<Order?> GetOrderAsync(int userId)
        {
            await using var context = await _factory.CreateDbContextAsync();

            return await context.Orders
                .Include(_ => _.OrderProducts)
                .ThenInclude(_ => _.Product)
                .ThenInclude(_ => _!.Category)
                .FirstOrDefaultAsync(_ => _.UserId == userId);
        }

        public async Task AddOrderAsync(Order order)
        {
            await using var context = await _factory.CreateDbContextAsync();

            context.Orders.Add(order);
            await context.SaveChangesAsync();
        }

        public async Task RemoveOrderAsync(Order order)
        {
            await using var context = await _factory.CreateDbContextAsync();

            context.Orders.Remove(order);
            await context.SaveChangesAsync();
        }

        public async Task RemoveProductFromOrderAsync(OrderProduct orderProduct)
        {
            await using var context = await _factory.CreateDbContextAsync();

            context.OrderProducts.Remove(orderProduct);
            await context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await using var context = await _factory.CreateDbContextAsync();

            await context.SaveChangesAsync();
        }
    }
}
