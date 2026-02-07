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

        public async Task<bool> PayAsync(int userId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var user = await _context.Users
                    .Include(_ => _.Order)
                    .ThenInclude(_ => _!.OrderProducts)
                    .FirstOrDefaultAsync(_ => _.Id == userId);

                if (user is null || user.Order is null 
                    || user.Order.OrderProducts.Count == 0)
                {
                    return false;
                }                    

                var total = user.Order.OrderProducts.Sum(x => x.UnitPrice * x.Quantity);

                if (total <= 0 || user.Money < total)
                {
                    return false;
                }

                user.Money -= total;

                _context.Orders.Remove(user.Order);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }            
        }
    }
}
