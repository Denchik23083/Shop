using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;
using Shop.Services.GodService;

namespace Shop.Web.Components.PagesComponents.AdminComponents
{
    public partial class AdminToUserModalComponent
    {
        [Parameter] public required User Admin { get; set; }

        [Parameter] public bool IsAdminToUserOpen { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; } = null!;

        [Inject] public IGodService Service { get; set; } = null!;

        private bool _isShowMessage;
        private bool _isSuccess;
        private string _messageText = "";

        private void CloseAdminToUserModal() => IsAdminToUserOpen = false;

        private async Task AdminToUser(int adminId)
        {
            var result = await Service.AdminToUserAsync(adminId);

            await Task.Delay(500);

            _isSuccess = result;
            _messageText = result
                ? "Админ понижен до пользователя"
                : "Не удалось понизить админа";

            _isShowMessage = true;
            StateHasChanged();

            await Task.Delay(1500);

            _isShowMessage = false;
            StateHasChanged();

            if (result)
            {
                NavigationManager.NavigateTo("/admins", true);
            }
        }
    }
}
