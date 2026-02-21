using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;
using Shop.Services.AdminService;

namespace Shop.Web.Components.PagesComponents
{
    public partial class DeleteProductModalComponent
    {
        [Parameter] public required Product Product { get; set; }

        [Parameter] public bool IsDeleteOpen { get; set; }

        [Inject] public IAdminService Service { get; set; } = null!;

        [Inject] public NavigationManager NavigationManager { get; set; } = null!;

        private bool _isShowMessage;
        private bool _isSuccess;
        private string _messageText = "";

        private void CloseDeleteModal() => IsDeleteOpen = false;

        private async Task DeleteAsync()
        {
            var result = await Service.DeleteProductAsync(Product.Id);

            if (result)
            {
                await Service.DeleteFileAsync(Product.Image);
            }

            await Task.Delay(500);

            _isSuccess = result;
            _messageText = result
                ? "Товар полностью удален"
                : "Не удалось удалить товар";

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
    }
}
