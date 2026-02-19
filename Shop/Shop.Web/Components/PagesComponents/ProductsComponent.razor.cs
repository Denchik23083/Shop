using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Shop.Db.Entities;
using Shop.Services.ProductService;
using System.Security.Claims;

namespace Shop.Web.Components.PagesComponents
{
    public partial class ProductsComponent
    {
        [Parameter] public IEnumerable<Product> Lists { get; set; } = [];

        [Inject] public NavigationManager NavigationManager { get; set; } = null!;
        
        [Inject] public AuthenticationStateProvider AuthStateProvider { get; set; } = null!;

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
                var state = await AuthStateProvider.GetAuthenticationStateAsync();

                var userStrId = state.User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (!int.TryParse(userStrId, out var userId))
                {
                    NavigationManager.NavigateTo("/login");

                    return;
                }

                var result = await Service.AddProductToOrderAsync(productId, userId);

                await Task.Delay(500);

                _addingProductId = null;
                StateHasChanged();

                _isSuccess = result;
                _messageText = result
                    ? "Товар добавлен в корзину"
                    : "Товар просрочен";

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

        private void Details(int productId)
        {
            NavigationManager.NavigateTo($"/products/{productId}");
        }
    }
}
