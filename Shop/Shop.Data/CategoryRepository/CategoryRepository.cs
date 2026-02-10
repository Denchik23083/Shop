using Microsoft.EntityFrameworkCore;
using Shop.Db;
using Shop.Db.Entities;

namespace Shop.Data.CategoryRepository
{
    public class CategoryRepository(IDbContextFactory<ShopContext> factory) : ICategoryRepository
    {
        private readonly IDbContextFactory<ShopContext> _factory = factory;

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            await using var context = await _factory.CreateDbContextAsync();

            return await context.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category?> GetCategory(int id)
        {
            await using var context = await _factory.CreateDbContextAsync();

            return await context.Categories
                .Include(_ => _.Products)
                .FirstOrDefaultAsync(_ => _.Id == id);
        }
    }
}
