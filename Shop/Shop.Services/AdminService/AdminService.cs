using Shop.Contracts.Models;
using Shop.Data.AdminRepository;
using Shop.Data.DbContextScopeFactory;
using Shop.Data.ProductRepository;
using Shop.Data.UserRepository;
using Shop.Db.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Components.Forms;

namespace Shop.Services.AdminService
{
    public class AdminService(IAdminRepository repository,
            IDbContextScopeFactory dbContextScopeFactory,
            IProductRepository productRepository,
            IUserRepository userRepository,
            IWebHostEnvironment webHost) : IAdminService
    {
        private readonly IAdminRepository _repository = repository;
        private readonly IDbContextScopeFactory _dbContextScopeFactory = dbContextScopeFactory;
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IWebHostEnvironment _webHost = webHost;

        public async Task<Balance?> GetBalance()
        {
            await using var context = await _dbContextScopeFactory.GetSingleDbContextAsync();

            return await _repository.GetBalance(context);
        }

        public async Task<string?> SaveFileAsync(IBrowserFile selectedFile)
        {
            var trustedFileName = Path.GetRandomFileName() + Path.GetExtension(selectedFile.Name);

            var path = Path.Combine(_webHost.WebRootPath, "img", "products", trustedFileName);

            var directory = Path.GetDirectoryName(path);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory!);
            }

            await using var stream = new FileStream(path, FileMode.Create);
            await selectedFile.OpenReadStream(maxAllowedSize: 1024 * 1024 * 10).CopyToAsync(stream);

            return Path.Combine("img", "products", trustedFileName).Replace("\\", "/");
        }

        public async Task<bool> AddQuantityAsync(int productId, int buyQuantity, int dayExpired)
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

                product.Count += buyQuantity;
                product.Expiration = DateTime.UtcNow.AddDays(dayExpired);
                
                var total = product.PurchasePrice * buyQuantity;
                
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

        public async Task<bool> PurchaseQuantityAsync(int productId, int purchaseQuantity)
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

                product.Count += purchaseQuantity;

                var total = product.PurchasePrice * purchaseQuantity;

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

        public async Task<bool> UpdateProductAsync(ProductEditModel productEditModel, int productId)
        {
            await using var context = await _dbContextScopeFactory.GetSingleDbContextAsync();

            var product = await _productRepository.GetProductAsync(context, productId);

            if (product is null)
            {
                return false;
            }

            product.Name = productEditModel.Name;
            product.PurchasePrice = productEditModel.PurchasePrice;
            product.Price = productEditModel.Price;
            product.CategoryId = productEditModel.CategoryId;

            await _dbContextScopeFactory.SaveChangesAsync(context);

            return true;
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

        public async Task<bool> DeleteProductAsync(int productId)
        {
            await using var context = await _dbContextScopeFactory.GetSingleDbContextAsync();

            var product = await _productRepository.GetProductAsync(context, productId);

            if (product is null)
            {
                return false;
            }

            await _productRepository.DeleteProductAsync(context, product);

            return true;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            await using var context = await _dbContextScopeFactory.GetSingleDbContextAsync();

            var user = await _userRepository.GetUserAsync(context, userId);

            if (user is null)
            {
                return false;
            }

            await _userRepository.DeleteUserAsync(context, user);

            return true;
        }
    }
}
