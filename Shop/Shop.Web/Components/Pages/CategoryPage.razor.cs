using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;
using Shop.Services.CategoryService;

namespace Shop.Web.Components.Pages
{
    public partial class CategoryPage
    {
        [Inject] public ICategoryService Service { get; set; } = null!;

        private IEnumerable<Category> Lists = [];

        protected override async Task OnInitializedAsync()
        {
            Lists = await Service.GetAllCategoriesAsync();
        }
    }
}
