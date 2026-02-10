using Microsoft.AspNetCore.Components;

namespace Shop.Web.Components.PagesComponents
{
    public partial class RedirectToLogin
    {
        [Inject] public NavigationManager NavigationManager { get; set; } = null!;

        protected override void OnInitialized()
        {
            NavigationManager.NavigateTo("/login", true);
        }
    }
}
