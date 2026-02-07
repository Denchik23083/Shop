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

        public async Task<bool> IncreaseQuantityAsync(int productId, Order order)
        {
            var orderProduct = order.OrderProducts.FirstOrDefault(_ => _.ProductId == productId);

            if (orderProduct is null || orderProduct.Product is null)
            {
                return false;
            }

            if (orderProduct.Quantity >= orderProduct.Product.Count)
            {
                return false;
            }

            orderProduct.Quantity++;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DecreaseQuantityAsync(int productId, Order order)
        {
            var orderProduct = order.OrderProducts.FirstOrDefault(_ => _.ProductId == productId);

            if (orderProduct is null || orderProduct.Product is null)
            {
                return false;
            }

            if (orderProduct.Quantity <= 1)
            {
                return false;
            }

            orderProduct.Quantity--;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveProductFromOrderAsync(int productId, Order order)
        {
            var orderProduct = order.OrderProducts.FirstOrDefault(_ => _.ProductId == productId);

            if (orderProduct is null || orderProduct.Product is null)
            {
                return false;
            }

            _context.OrderProducts.Remove(orderProduct);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
