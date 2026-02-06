using Microsoft.EntityFrameworkCore;
using Shop.Db;
using Shop.Db.Entities;
using System.Reflection.Metadata.Ecma335;

namespace Shop.Services.ProductService
{
    public class ProductService(ShopContext context) : IProductService
    {
        private readonly ShopContext _context = context;

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> AddToOrderAsync(int productId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var product = await _context.Products
                    .FirstOrDefaultAsync(_ => _.Id == productId);

                if (product is null)
                {
                    await transaction.RollbackAsync();
                    return false;
                }

                //TODO: Костыль. В дальнейшем изменить на cookies. На данный 
                //момент у нас 1 user с id = 1.

                var userId = 1;

                var user = await _context.Users
                    .FirstOrDefaultAsync(_ => _.Id == userId);

                if (user is null)
                {
                    await transaction.RollbackAsync();
                    return false;
                }

                var order = await _context.Orders
                    .Include(_ => _.OrderProducts)
                    .FirstOrDefaultAsync(_ => _.UserId == user.Id);

                if (order is null)
                {
                    order = new()
                    {
                        CreatedAt = DateTime.UtcNow,
                        UserId = user.Id,
                    };

                    _context.Orders.Add(order);
                    await _context.SaveChangesAsync();
                }

                var orderProduct = order.OrderProducts.FirstOrDefault(_ => _.ProductId == productId);

                if (orderProduct is null)
                {
                    order.OrderProducts.Add(new OrderProduct
                    {
                        ProductId = product.Id,
                        OrderId = order.Id,
                        UnitPrice = product.Price,
                        Quantity = 1
                    });
                }
                else
                {
                    orderProduct.Quantity++;
                }

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
