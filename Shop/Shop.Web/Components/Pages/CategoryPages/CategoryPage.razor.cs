using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;
using Shop.Services.CategoryService;

namespace Shop.Web.Components.Pages.CategoryPages
{
    public partial class CategoryPage
    {
        [Inject] public ICategoryService Service { get; set; } = null!;

        private IEnumerable<Category> Categories = [];

        protected override async Task OnInitializedAsync()
        {
            Categories = await Service.GetAllCategoriesAsync();
        }
    }
}
