using Microsoft.AspNetCore.Components;
using Shop.Contracts.Models;
using Shop.Services.UserService;

namespace Shop.Web.Components.Pages
{
    public partial class LoginPage
    {
        [Inject] public IUserService UserService { get; set; } = null!;

        [Inject] public NavigationManager NavigationManager { get; set; } = null!;

        private readonly LoginModel LoginModel = new();

        public async Task Login()
        {
            var result = await UserService.LoginUserAsync(LoginModel);
        }
    }
}
