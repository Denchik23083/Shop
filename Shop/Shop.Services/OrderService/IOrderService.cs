using Shop.Db.Entities;

namespace Shop.Services.OrderService
{
    public interface IOrderService
    {
        Task<Order?> GetOrder(int userId);
    }
}