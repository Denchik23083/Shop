using Shop.Db;

namespace Shop.Data.DbContextScopeFactory
{
    public interface IDbContextScopeFactory
    {
        Task<ShopContext> GetSingleDbContextAsync();
    }
}