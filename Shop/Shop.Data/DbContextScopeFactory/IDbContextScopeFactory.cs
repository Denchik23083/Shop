using Shop.Db;

namespace Shop.Data.DbContextScopeFactory
{
    public interface IDbContextScopeFactory
    {
        Task<ShopContext> GetSingleDbContextAsync();

        Task SaveChangesAsync(ShopContext context);
    }
}