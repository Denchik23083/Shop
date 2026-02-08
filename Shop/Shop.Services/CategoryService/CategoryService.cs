using Shop.Data.CategoryRepository;
using Shop.Db.Entities;

namespace Shop.Services.CategoryService
{
    public class CategoryService(ICategoryRepository repository) : ICategoryService
    {
        private readonly ICategoryRepository _repository = repository;

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _repository.GetAllCategoriesAsync();
        }

        public async Task<Category?> GetCategoryAsync(int id)
        {
            return await _repository.GetCategory(id);
        }
    }
}
