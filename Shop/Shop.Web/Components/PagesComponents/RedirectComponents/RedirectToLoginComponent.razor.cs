using Microsoft.AspNetCore.Components;

namespace Shop.Web.Components.PagesComponents.RedirectComponents
{
    public partial class RedirectToLoginComponent
    {
        [Inject] public NavigationManager NavigationManager { get; set; } = null!;

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                NavigationManager.NavigateTo("/login", true);
            }
        }
    }
}
