using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;
using Shop.Services.ProductService;

namespace Shop.Web.Components.Pages
{
    public partial class ProductDetailsPage
    {
        [Parameter] public int ProductId { get; set; }

        [Inject] public IProductService Service { get; set; } = null!;

        private Product? Product { get; set; }
        private bool _isLoading = true;
        private bool _isManageOpen;
        private bool _isEditOpen;

        protected override async Task OnInitializedAsync()
        {
            Product = await Service.GetProductAsync(ProductId);

            await Task.Delay(500);

            _isLoading = false;
        }

        private void OpenManageModal()
        {
            _isEditOpen = false;
            _isManageOpen = true;
        }

        private void OpenEditModal()
        {
            _isManageOpen = false;
            _isEditOpen = true;
        }
    }
}
