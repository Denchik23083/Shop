using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;
using Shop.Services.AdminService;

namespace Shop.Web.Components.PagesComponents
{
    public partial class ManageProductModalComponent
    {
        [Parameter] public required Product Product { get; set; }

        [Parameter] public bool IsManageOpen { get; set; }

        [Inject] public IAdminService Service { get; set; } = null!;

        [Inject] public NavigationManager NavigationManager { get; set; } = null!;

        private int _purchaseQuantity = 1;
        private int _buyQuantity = 1;
        private bool _isShowMessage;
        private bool _isSuccess;
        private string _messageText = "";

        private void CloseManageModal() => IsManageOpen = false;

        private async Task AddQuantityAsync()
        {
            var result = await Service.AddQuantityAsync(Product.Id, _buyQuantity);

            await Task.Delay(500);

            _isSuccess = result;
            _messageText = result
                ? "Новые товары куплены"
                : "Не удалось купить товары";

            await ShowMessageAsync(result);
        }

        private async Task PurchaseQuantityAsync()
        {
            var result = await Service.AddQuantityAsync(Product.Id, _purchaseQuantity);

            await Task.Delay(500);

            _isSuccess = result;
            _messageText = result
                ? "Новые товары докуплены"
                : "Не удалось докупить товары";

            await ShowMessageAsync(result);
        }

        private async Task DeleteAllQuantityAsync()
        {
            var result = await Service.DeleteAllQuantityAsync(Product.Id);

            await Task.Delay(500);

            _isSuccess = result;
            _messageText = result
                ? "Просроченые товары удалены"
                : "Не удалось удалить товары";

            await ShowMessageAsync(result);
        }

        private async Task ShowMessageAsync(bool result)
        {
            _isShowMessage = true;
            StateHasChanged();

            await Task.Delay(1500);

            _isShowMessage = false;
            StateHasChanged();

            if (result)
            {
                NavigationManager.NavigateTo($"/products/{Product.Id}", true);
            }
        }
    }
}
