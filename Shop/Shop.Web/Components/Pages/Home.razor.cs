using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;
using Shop.Services.ProductService;

namespace Shop.Web.Components.Pages
{
    public partial class Home() 
    {
        [Inject] private IProductService Service { get; set; } = null!;
        
        private IEnumerable<Product> Lists = [];

        protected override async Task OnInitializedAsync()
        {
            Lists = await Service.GetAllProductsAsync();
        }

        public async Task InCartAsync(int productId)
        {
            await Service.AddToOrderAsync(productId);
        }
    }
}
