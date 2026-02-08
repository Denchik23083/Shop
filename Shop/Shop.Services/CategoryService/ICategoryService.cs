using Shop.Db.Entities;

namespace Shop.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        Task<Category?> GetCategoryAsync(int id); 
    }
}