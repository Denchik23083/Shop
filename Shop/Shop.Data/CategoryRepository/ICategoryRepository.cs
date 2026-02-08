using Shop.Db.Entities;

namespace Shop.Data.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        Task<Category?> GetCategory(int id);
    }
}