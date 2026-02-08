using Shop.Db.Entities;

namespace Shop.Services.OrderService
{
    public interface IOrderService
    {
        Task<Order?> GetOrderAsync(int userId);

        Task<bool> IncreaseQuantityAsync(int productId, Order order);

        Task<bool> DecreaseQuantityAsync(int productId, Order order);

        Task<bool> RemoveProductFromOrderAsync(int productId, Order order);
    
        Task<bool> PayAsync(int userId);
    }
}