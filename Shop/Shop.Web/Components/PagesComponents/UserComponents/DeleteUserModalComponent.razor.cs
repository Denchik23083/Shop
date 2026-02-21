using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;
using Shop.Services.AdminService;

namespace Shop.Web.Components.PagesComponents.UserComponents
{
    public partial class DeleteUserModalComponent
    {
        [Parameter] public required User User { get; set; }

        [Parameter] public bool IsDeleteUserOpen { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; } = null!;

        [Inject] public IAdminService Service { get; set; } = null!;

        private bool _isShowMessage;
        private bool _isSuccess;
        private string _messageText = "";

        private void CloseDeleteUserModal() => IsDeleteUserOpen = false;

        private async Task DeleteUser(int userId)
        {
            var result = await Service.DeleteUserAsync(userId);

            await Task.Delay(500);

            _isSuccess = result;
            _messageText = result
                ? "Пользователь удален"
                : "Не удалось удалить пользователя";

            _isShowMessage = true;
            StateHasChanged();

            await Task.Delay(1500);

            _isShowMessage = false;
            StateHasChanged();

            if (result)
            {
                NavigationManager.NavigateTo("/users", true);
            }
        }
    }
}
