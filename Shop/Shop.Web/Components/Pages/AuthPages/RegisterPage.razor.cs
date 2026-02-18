using Microsoft.AspNetCore.Components;
using Shop.Contracts.Models;
using Shop.Services.UserService;

namespace Shop.Web.Components.Pages.AuthPages
{
    public partial class RegisterPage
    {
        [Inject] public IUserService UserService { get; set; } = null!;

        [Inject] public NavigationManager NavigationManager { get; set; } = null!;

        private readonly RegisterModel RegisterModel = new();
        private bool _isShowMessage;
        private bool _isSuccess;
        private string _messageText = "";

        public async Task Register()
        {
            var result = await UserService.RegisterUserAsync(RegisterModel);

            _isSuccess = result;
            _messageText = result
                ? "Вы успешно зарегистрировались"
                : "Не удалось зарегистрироваться";
                
            _isShowMessage = true;
            StateHasChanged();

            await Task.Delay(1500);

            _isShowMessage = false;
            StateHasChanged();

            if (result)
            {
                NavigationManager.NavigateTo("/login");
            }
        }
    }
}
