using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;
using Shop.Services.ProductService;

namespace Shop.Web.Components.Pages
{
    public partial class Home() 
    {
        [Inject] private IProductService Service { get; set; } = null!;
        
        private IEnumerable<Product> Lists = [];
        private bool _isShowMessage;
        private bool _isSuccess;
        private string _messageText = "";
        private int? _addingProductId;

        protected override async Task OnInitializedAsync()
        {
            Lists = await Service.GetAllProductsAsync();
        }

        public async Task InCartAsync(int productId)
        {
            _addingProductId = productId;
            StateHasChanged();

            try
            {
                var result = await Service.AddToOrderAsync(productId);
                
                await Task.Delay(1000);

                _addingProductId = null;
                StateHasChanged();

                _isSuccess = result;
                _messageText = result
                    ? "Товар добавлен в корзину"
                    : "Не удалось добавить товар";

                _isShowMessage = true;
                StateHasChanged();

                await Task.Delay(1500);

                _isShowMessage = false;
                StateHasChanged();
            }
            finally
            {
                _addingProductId = null;
                StateHasChanged();
            }            
        }
    }
}
