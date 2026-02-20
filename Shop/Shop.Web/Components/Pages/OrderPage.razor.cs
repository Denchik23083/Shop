using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Shop.Db.Entities;
using Shop.Services.OrderService;
using System.Security.Claims;

namespace Shop.Web.Components.Pages
{
    public partial class OrderPage
    {
        [Inject] public IOrderService Service { get; set; } = null!;
        
        [Inject] public AuthenticationStateProvider AuthStateProvider { get; set; } = null!;

        [Inject] public NavigationManager NavigationManager { get; set; } = null!;

        private Order? Order { get; set; }

        private bool _isShowMessage;
        private bool _isSuccess;
        private string _messageText = "";
        private bool _isLoading = true;

        private decimal Total => Order?.OrderProducts
            .Sum(x => x.UnitPrice * x.Quantity) ?? 0m;

        protected override async Task OnInitializedAsync()
        {
            var state = await AuthStateProvider.GetAuthenticationStateAsync();

            var userStrId = state.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userStrId, out var userId))
            {
                Order = null;
                await Task.Delay(500);

                _isLoading = false;

                return;
            }

            Order = await Service.GetOrderAsync(userId);

            await Task.Delay(500);

            _isLoading = false;
        }

        private async Task PayAsync()
        {
            var state = await AuthStateProvider.GetAuthenticationStateAsync();

            var userStrId = state.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userStrId, out var userId))
            {
                return;
            }
            
            var result = await Service.PayAsync(userId);

            await Task.Delay(500);

            _isSuccess = result;
            _messageText = result
                ? "Заказ оплачен"
                : "Не удалось оплатить";

            _isShowMessage = true;
            StateHasChanged();

            await Task.Delay(1500);

            _isShowMessage = false;
            StateHasChanged();

            if (result)
            {
                NavigationManager.NavigateTo("/", true);
            }
        }

        private async Task DeleteProductFromOrderAsync(int productId)
        {
            if (Order is null) return;

            var result = await Service.DeleteProductFromOrderAsync(productId, Order.Id);

            if (!result)
            {
                _messageText = "Не удалось удалить товар";
                await ShowMessageAsync();

                return;
            }

            var local = Order.OrderProducts.FirstOrDefault(_ => _.ProductId == productId);
            if (local is null) return;

            Order.OrderProducts.Remove(local);
        }

        private async Task IncreaseQuantityAsync(int productId)
        {
            if (Order is null) return;

            var result = await Service.IncreaseQuantityAsync(productId, Order.Id);

            if (!result)
            {
                _messageText = "Достигнут максимум";
                await ShowMessageAsync();

                return;
            }

            var local = Order.OrderProducts.FirstOrDefault(_ => _.ProductId == productId);
            if (local is null) return;
                
            local.Quantity++;
        }

        private async Task DecreaseQuantityAsync(int productId)
        {
            if (Order is null) return;

            var result = await Service.DecreaseQuantityAsync(productId, Order.Id);

            if (!result)
            {
                _messageText = "Достигнут минимум";
                await ShowMessageAsync();

                return;
            }

            var local = Order.OrderProducts.FirstOrDefault(_ => _.ProductId == productId);
            if (local is null) return;
                    
            local.Quantity--;
        }

        private async Task ShowMessageAsync()
        {
            _isShowMessage = true;
            StateHasChanged();

            await Task.Delay(1500);

            _isShowMessage = false;
            StateHasChanged();
        }
    }
}
