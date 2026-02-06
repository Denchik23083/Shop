using Microsoft.EntityFrameworkCore;
using Shop.Db;
using Shop.Db.Entities;

namespace Shop.Services.CategoryService
{
    public class CategoryService(ShopContext context) : ICategoryService
    {
        private readonly ShopContext _context = context;

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .Include(_ => _.Products)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
