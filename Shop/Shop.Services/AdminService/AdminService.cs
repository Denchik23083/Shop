using Shop.Data.AdminRepository;
using Shop.Data.DbContextScopeFactory;
using Shop.Db.Entities;

namespace Shop.Services.AdminService
{
    public class AdminService(IAdminRepository repository,
            IDbContextScopeFactory dbContextScopeFactory) : IAdminService
    {
        private readonly IAdminRepository _repository = repository;
        private readonly IDbContextScopeFactory _dbContextScopeFactory = dbContextScopeFactory;

        public async Task<Balance?> GetBalance()
        {
            await using var context = await _dbContextScopeFactory.GetSingleDbContextAsync();

            return await _repository.GetBalance(context);
        }
    }
}
