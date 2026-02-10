
using Microsoft.EntityFrameworkCore;
using Shop.Db;

namespace Shop.Data.DbContextScopeFactory
{
    public class DbContextScopeFactory(IDbContextFactory<ShopContext> factory) : IDbContextScopeFactory
    {
        private readonly IDbContextFactory<ShopContext> _factory = factory;

        public async Task<ShopContext> GetSingleDbContextAsync()
        {
            return await _factory.CreateDbContextAsync();
        }
    }
}
