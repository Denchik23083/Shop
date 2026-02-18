using Shop.Data.AdminRepository;
using Shop.Data.DbContextScopeFactory;
using Shop.Data.ProductRepository;
using Shop.Db.Entities;

namespace Shop.Services.AdminService
{
    public class AdminService(IAdminRepository repository,
            IDbContextScopeFactory dbContextScopeFactory,
            IProductRepository productRepository) : IAdminService
    {
        private readonly IAdminRepository _repository = repository;
        private readonly IDbContextScopeFactory _dbContextScopeFactory = dbContextScopeFactory;
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<Balance?> GetBalance()
        {
            await using var context = await _dbContextScopeFactory.GetSingleDbContextAsync();

            return await _repository.GetBalance(context);
        }

        public async Task<bool> AddQuantityAsync(int productId, int quantity)
        {
            await using var context = await _dbContextScopeFactory.GetSingleDbContextAsync();

            await using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                var product = await _productRepository.GetProductAsync(context, productId);

                if (product is null)
                {
                    return false;
                }

                var balance = await _repository.GetBalance(context);

                if (balance is null)
                {
                    return false;
                }

                product.Count += quantity;

                var total = product.PurchasePrice * quantity;
                
                balance.Money -= total;
                balance.TotalExpense += total;

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

        public async Task<bool> DeleteAllQuantityAsync(int productId)
        {
            await using var context = await _dbContextScopeFactory.GetSingleDbContextAsync();

            var product = await _productRepository.GetProductAsync(context, productId);

            if (product is null)
            {
                return false;
            }

            product.Count = 0;

            await _dbContextScopeFactory.SaveChangesAsync(context);

            return true;
        }
    }
}
