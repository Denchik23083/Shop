using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shop.Contracts.Models;

namespace Shop.Web.Components.Pages
{
    public partial class LoginPage
    {
        [Inject] public IJSRuntime JS { get; set; } = null!;

        [Inject] public NavigationManager NavigationManager { get; set; } = null!;

        private readonly LoginModel LoginModel = new();
        private bool _isShowMessage;
        private bool _isSuccess;
        private string _messageText = "";

        public async Task Login()
        {
            var result = await JS.InvokeAsync<bool>("auth.login", LoginModel);

            _isSuccess = result;
            _messageText = result
                ? "Вы успешно вошли"
                : "Не удалось войти";

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
