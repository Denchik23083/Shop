using Microsoft.EntityFrameworkCore;
using Shop.Db;
using Shop.Db.Entities;

namespace Shop.Data.CategoryRepository
{
    public class CategoryRepository(ShopContext context) : ICategoryRepository
    {
        private readonly ShopContext _context = context;

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category?> GetCategory(int id)
        {
            return await _context.Categories
                .Include(_ => _.Products)
                .FirstOrDefaultAsync(_ => _.Id == id);
        }
    }
}
