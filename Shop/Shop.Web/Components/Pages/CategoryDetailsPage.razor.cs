using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;
using Shop.Services.CategoryService;

namespace Shop.Web.Components.Pages
{
    public partial class CategoryDetailsPage
    {
        [Parameter] public int CategoryId { get; set; }

        [Inject] public ICategoryService Service { get; set; } = null!;

        private Category? Category { get; set; }
        private bool _isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            Category = await Service.GetCategoryAsync(CategoryId);

            await Task.Delay(1000);

            _isLoading = false;
        }
    }
}
