using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;
using Shop.Services.ProductService;

namespace Shop.Web.Components.PagesComponents
{
    public partial class ProductsComponent
    {
        [Parameter] public IEnumerable<Product> Lists { get; set; } = [];

        [Inject] public IProductService Service { get; set; } = null!;

        private bool _isShowMessage;
        private bool _isSuccess;
        private string _messageText = "";
        private int? _addingProductId;

        public async Task InCartAsync(int productId)
        {
            _addingProductId = productId;
            StateHasChanged();

            try
            {
                var result = await Service.AddProductToOrderAsync(productId);

                await Task.Delay(1000);

                _addingProductId = null;
                StateHasChanged();

                _isSuccess = result;
                _messageText = result
                    ? "Товар добавлен в корзину"
                    : "Достигнут максимум";

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
