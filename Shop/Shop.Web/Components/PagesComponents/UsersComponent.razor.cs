using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;
using Shop.Services.AdminService;
using Shop.Services.GodService;

namespace Shop.Web.Components.PagesComponents
{
    public partial class UsersComponent
    {
        [Parameter] public IEnumerable<User> Users { get; set; } = [];
                
        [Inject] public NavigationManager NavigationManager { get; set; } = null!;

        [Inject] public IAdminService Service { get; set; } = null!;

        [Inject] public IGodService GodService { get; set; } = null!;
        
        private bool _isShowMessage;
        private bool _isSuccess;
        private string _messageText = "";

        private async Task UserToAdmin(int userId)
        {
            var result = await GodService.UserToAdminAsync(userId);

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

        private async Task DeleteUser(int userId)
        {
            //TODO:
            
            /*

            var result = await GodService.UserToAdminAsync(userId);

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
            }*/
        }
    }
}
