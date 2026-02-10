using Shop.Db;
using Shop.Db.Entities;

namespace Shop.Data.OrderRepository
{
    public interface IOrderRepository
    {
        Task<Order?> GetOrderAsync(ShopContext context, int userId);

        Task<OrderProduct?> GetOrderProductAsync(ShopContext context, int productId, int orderId);

        Task AddOrderAsync(ShopContext context, Order order);

        Task RemoveOrderAsync(ShopContext context, Order order);

        Task RemoveProductFromOrderAsync(ShopContext context, OrderProduct orderProduct);

        Task SaveChangesAsync(ShopContext context);
    }
}