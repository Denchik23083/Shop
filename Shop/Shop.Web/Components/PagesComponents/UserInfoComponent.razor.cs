using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Shop.Db.Entities;
using Shop.Db.Migrations;
using Shop.Services.UserService;
using System.Security.Claims;

namespace Shop.Web.Components.PagesComponents
{
    public partial class UserInfoComponent
    {
        [Inject] public IUserService Service { get; set; } = null!;

        [Inject] public AuthenticationStateProvider AuthStateProvider { get; set; } = null!;

        [Inject] public IJSRuntime JS { get; set; } = null!;

        [Inject] public NavigationManager NavigationManager { get; set; } = null!;

        private decimal UserMoney;
        private string? UserName = "";
        private bool _isShowMessage;
        private bool _isSuccess;
        private string _messageText = "";

        protected override async Task OnInitializedAsync()
        {
            var state = await AuthStateProvider.GetAuthenticationStateAsync();

            var userStrId = state.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userStrId, out var userId)) return;

            UserName = state.User.Identity?.Name;
            UserMoney = await Service.GetMoneyAsync(userId);
        }

        public async Task Logout()
        {
            var result = await JS.InvokeAsync<bool>("auth.logout", null);

            _isSuccess = result;
            _messageText = result
                ? "Вы успешно вышли"
                : "Не удалось выйти";

            _isShowMessage = true;
            StateHasChanged();

            await Task.Delay(1500);

            _isShowMessage = false;
            StateHasChanged();

            if (result)
            {
                NavigationManager.NavigateTo("/login", true);
            }
        }
    }
}
