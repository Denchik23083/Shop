using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;
using Shop.Services.ProductService;

namespace Shop.Web.Components.Pages
{
    public partial class HomePage
    {
        [Inject] public IProductService Service { get; set; } = null!;
        
        private IEnumerable<Product> Products = [];

        private bool _isAddProductOpen;

        protected override async Task OnInitializedAsync()
        {
            Products = await Service.GetAllProductsAsync();
        }

        private void OpenAddProductModal() => _isAddProductOpen = true;
    }
}
