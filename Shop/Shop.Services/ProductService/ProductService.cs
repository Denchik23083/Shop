using Shop.Data.DbContextScopeFactory;
using Shop.Data.OrderRepository;
using Shop.Data.ProductRepository;
using Shop.Data.UserRepository;
using Shop.Db.Entities;

namespace Shop.Services.ProductService
{
    public class ProductService(IProductRepository repository, 
            IOrderRepository orderRepository,
            IUserRepository userRepository,
            IDbContextScopeFactory dbContextScopeFactory) : IProductService
    {
        private readonly IProductRepository _repository = repository;
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IDbContextScopeFactory _dbContextScopeFactory = dbContextScopeFactory;

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _repository.GetAllProductsAsync();
        }

        public async Task<Product?> GetProductAsync(int productId)
        {
            await using var context = await _dbContextScopeFactory.GetSingleDbContextAsync();

            return await _repository.GetProductAsync(context, productId);
        }

        public async Task<bool> AddProductToOrderAsync(int productId, int userId)
        {
            await using var context = await _dbContextScopeFactory.GetSingleDbContextAsync();

            await using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                var product = await _repository.GetProductAsync(context, productId);

                if (product is null)
                {
                    return false;
                }

                var user = await _userRepository.GetUserAsync(context, userId);

                if (user is null)
                {
                    return false;
                }

                //если нет заказа то создаем
                if (user.Order is null)
                {
                    user.Order = new()
                    {
                        CreatedAt = DateTime.UtcNow,
                        UserId = user.Id
                    };

                    await _orderRepository.AddOrderAsync(context, user.Order);
                }

                //если нет товаров в заказе то создаем и добавляем
                var orderProduct = user.Order.OrderProducts.FirstOrDefault(_ => _.ProductId == productId);

                if (orderProduct is null)
                {
                    user.Order.OrderProducts.Add(new OrderProduct
                    {
                        ProductId = product.Id,
                        UnitPrice = product.Price,
                        Quantity = 1
                    });
                }
                else
                {
                    //проверяем что б товар был на складе
                    if (orderProduct.Quantity >= product.Count)
                    {
                        return false;
                    }

                    orderProduct.Quantity++;
                }

                await _dbContextScopeFactory.SaveChangesAsync(context);
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
