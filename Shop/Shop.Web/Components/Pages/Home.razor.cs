using Shop.Db;
using Shop.Db.Entities;
using Shop.Services;

namespace Shop.Web.Components.Pages
{
    public partial class Home(IProductService service) 
    {
        private readonly IProductService _service = service;
        private IEnumerable<Product> Lists = [];

        protected override async Task OnInitializedAsync()
        {
            Lists = await _service.GetAllProducts();
        }
    }
}
