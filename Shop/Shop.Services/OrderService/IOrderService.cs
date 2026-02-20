using Shop.Db.Entities;

namespace Shop.Services.OrderService
{
    public interface IOrderService
    {
        Task<Order?> GetOrderAsync(int userId);

        Task<bool> IncreaseQuantityAsync(int productId, int orderId);

        Task<bool> DecreaseQuantityAsync(int productId, int orderId);

        Task<bool> DeleteProductFromOrderAsync(int productId, int orderId);
    
        Task<bool> PayAsync(int userId);
    }
}