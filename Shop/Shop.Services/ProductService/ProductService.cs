using Microsoft.EntityFrameworkCore;
using Shop.Db;
using Shop.Db.Entities;

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

        public async Task AddToOrderAsync(int productId)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(_ => _.Id == productId);

            if (product is null)
            {
                return;
            }

            //TODO: Костыль. В дальнейшем изменить на cookies. На данный 
            //момент у нас 1 user с id = 1.

            var userId = 1;

            var user = await _context.Users
                .FirstOrDefaultAsync(_ => _.Id == userId);

            //TODO: Костыль 2. В дальнейшем изменить orderId. На данный 
            //момент у нас 1 order с id = 1. 
            var orderId = 1;

            var order = await _context.Orders
                .Include(_ => _.OrderProducts)
                .FirstOrDefaultAsync(_ => _.Id == orderId);

            if (order is null)
            {
                order = new()
                {
                    CreatedAt = DateTime.UtcNow,
                    UserId = user!.Id,
                };

                await _context.AddAsync(order);
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
        }
    }
}
