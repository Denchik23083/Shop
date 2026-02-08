using Microsoft.EntityFrameworkCore.Storage;
using Shop.Db.Entities;

namespace Shop.Data.OrderRepository
{
    public interface IOrderRepository
    {
        Task<IDbContextTransaction> BeginTransactionAsync();

        Task<Order?> GetOrderAsync(int userId);

        Task AddOrderAsync(Order order);

        Task RemoveOrderAsync(Order order);

        Task RemoveProductFromOrderAsync(OrderProduct orderProduct);

        Task SaveChangesAsync();
    }
}