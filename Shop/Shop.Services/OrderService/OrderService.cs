using Shop.Data.DbContextScopeFactory;
using Shop.Data.OrderRepository;
using Shop.Data.UserRepository;
using Shop.Db.Entities;

namespace Shop.Services.OrderService
{
    public class OrderService(IOrderRepository repository, 
            IUserRepository userRepository,
            IDbContextScopeFactory dbContextScopeFactory) : IOrderService
    {
        private readonly IOrderRepository _repository = repository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IDbContextScopeFactory _dbContextScopeFactory = dbContextScopeFactory;

        public async Task<Order?> GetOrderAsync(int userId)
        {
            return await _repository.GetOrderAsync(userId);
        }

        public async Task<bool> IncreaseQuantityAsync(int productId, int orderId)
        {
            await using var context = await _dbContextScopeFactory.GetSingleDbContextAsync();

            var orderProduct = await _repository.GetOrderProductAsync(context, productId, orderId);

            if (orderProduct is null || orderProduct.Product is null)
            {
                return false;
            }

            if (orderProduct.Quantity >= orderProduct.Product.Count)
            {
                return false;
            }

            orderProduct.Quantity++;

            await _dbContextScopeFactory.SaveChangesAsync(context);

            return true;
        }

        public async Task<bool> DecreaseQuantityAsync(int productId, int orderId)
        {
            await using var context = await _dbContextScopeFactory.GetSingleDbContextAsync();

            var orderProduct = await _repository.GetOrderProductAsync(context, productId, orderId);

            if (orderProduct is null || orderProduct.Product is null)
            {
                return false;
            }

            if (orderProduct.Quantity <= 1)
            {
                return false;
            }

            orderProduct.Quantity--;

            await _dbContextScopeFactory.SaveChangesAsync(context);

            return true;
        }

        public async Task<bool> RemoveProductFromOrderAsync(int productId, int orderId)
        {
            await using var context = await _dbContextScopeFactory.GetSingleDbContextAsync();

            var orderProduct = await _repository.GetOrderProductAsync(context, productId, orderId);

            if (orderProduct is null || orderProduct.Product is null)
            {
                return false;
            }

            await _repository.RemoveProductFromOrderAsync(context, orderProduct);

            return true;
        }

        public async Task<bool> PayAsync(int userId)
        {
            await using var context = await _dbContextScopeFactory.GetSingleDbContextAsync();

            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                var user = await _userRepository.GetUserAsync(context, userId);

                if (user is null || user.Order is null 
                    || user.Order.OrderProducts.Count == 0)
                {
                    return false;
                }

                foreach (var orderProduct in user.Order.OrderProducts)
                {
                    if (orderProduct.Product is null
                        || orderProduct.Quantity <= 0
                        || orderProduct.Product.Count < orderProduct.Quantity)
                    {
                        return false;
                    }
                }

                //Конечная сума
                var total = user.Order.OrderProducts.Sum(x => x.UnitPrice * x.Quantity);

                if (total <= 0 || user.Money < total)
                {
                    return false;
                }

                //Списываем со счета
                user.Money -= total;

                //Списываем товары со склада
                foreach (var orderProduct in user.Order.OrderProducts)
                {
                    orderProduct.Product!.Count -= orderProduct.Quantity;
                }

                //Удаляем заказ
                await _repository.RemoveOrderAsync(context, user.Order);
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
