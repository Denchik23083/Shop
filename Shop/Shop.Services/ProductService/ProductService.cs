using Shop.Data.OrderRepository;
using Shop.Data.ProductRepository;
using Shop.Data.UserRepository;
using Shop.Db.Entities;

namespace Shop.Services.ProductService
{
    public class ProductService(IProductRepository repository, 
            IOrderRepository orderRepository,
            IUserRepository userRepository) : IProductService
    {
        private readonly IProductRepository _repository = repository;
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _repository.GetAllProductsAsync();
        }

        public async Task<bool> AddProductToOrderAsync(int productId)
        {
            using var transaction = await _repository.BeginTransactionAsync();

            try
            {
                var product = await _repository.GetProductAsync(productId);

                if (product is null)
                {
                    return false;
                }

                //TODO: Костыль. В дальнейшем изменить на cookies. На данный 
                //момент у нас 1 user с id = 1.

                var userId = 1;

                var user = await _userRepository.GetUser(userId);

                if (user is null)
                {
                    return false;
                }

                if (user.Order is null)
                {
                    user.Order = new()
                    {
                        CreatedAt = DateTime.UtcNow,
                    };

                    await _orderRepository.AddOrderAsync(user.Order);
                }

                var orderProduct = user.Order.OrderProducts.FirstOrDefault(_ => _.ProductId == productId);

                if (orderProduct is null)
                {
                    user.Order.OrderProducts.Add(new OrderProduct
                    {
                        ProductId = product.Id,
                        OrderId = user.Order.Id,
                        UnitPrice = product.Price,
                        Quantity = 1
                    });
                }
                else
                {
                    if (orderProduct.Quantity >= product.Count)
                    {
                        return false;
                    }

                    orderProduct.Quantity++;
                }

                await _repository.SaveChangesAsync();
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
