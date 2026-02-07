using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;
using Shop.Services.OrderService;

namespace Shop.Web.Components.Pages
{
    public partial class OrderPage
    {
        [Inject] public IOrderService Service { get; set; } = null!;

        [Inject] public NavigationManager NavigationManager { get; set; } = null!;

        private Order? Order { get; set; }

        private bool _isShowMessage;
        private bool _isShowPayMessage;

        private decimal Total => Order?.OrderProducts
            .Sum(x => x.UnitPrice * x.Quantity) ?? 0m;

        private string _messageText = "";

        protected override async Task OnInitializedAsync()
        {
            //TODO: by UserId
            Order = await Service.GetOrder(1);
        }

        private async Task PayAsync()
        {
            //TODO: by UserId
            var result = await Service.PayAsync(1);

            if (result)
            {
                _messageText = "Заказ оплачен";

                _isShowPayMessage = true;
                StateHasChanged();

                await Task.Delay(1500);

                _isShowPayMessage = false;
                StateHasChanged();

                NavigationManager.NavigateTo("/");
            }
            else 
            {
                _messageText = "Не удалось оплатить";
                await ShowMessageAsync();
            }
        }

        private async Task RemoveProductFromOrderAsync(int productId)
        {
            if (Order is null) return;

            var result = await Service.RemoveProductFromOrderAsync(productId, Order);

            if (!result)
            {
                _messageText = "Не удалось удалить товар";
                await ShowMessageAsync();
            }
        }

        private async Task IncreaseQuantityAsync(int productId)
        {
            if (Order is null) return;

            var result = await Service.IncreaseQuantityAsync(productId, Order);

            if (!result)
            {
                _messageText = "Достигнут максимум";
                await ShowMessageAsync();
            }
        }

        private async Task DecreaseQuantityAsync(int productId)
        {
            if (Order is null) return;

            var result = await Service.DecreaseQuantityAsync(productId, Order);

            if (!result)
            {
                _messageText = "Достигнут минимум";
                await ShowMessageAsync();
            }
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
