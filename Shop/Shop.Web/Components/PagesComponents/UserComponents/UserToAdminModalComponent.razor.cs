using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;
using Shop.Services.GodService;

namespace Shop.Web.Components.PagesComponents.UserComponents
{
    public partial class UserToAdminModalComponent
    {
        [Parameter] public required User User { get; set; }

        [Parameter] public bool IsUserToAdminOpen { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; } = null!;

        [Inject] public IGodService Service { get; set; } = null!;

        private bool _isShowMessage;
        private bool _isSuccess;
        private string _messageText = "";

        private void CloseUserToAdminModal() => IsUserToAdminOpen = false;

        private async Task UserToAdmin(int userId)
        {
            var result = await Service.UserToAdminAsync(userId);

            await Task.Delay(500);

            _isSuccess = result;
            _messageText = result
                ? "Пользователь повышен до админа"
                : "Не удалось повысить пользователя";

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
