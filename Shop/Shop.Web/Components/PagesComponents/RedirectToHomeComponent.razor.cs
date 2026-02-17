using Microsoft.AspNetCore.Components;

namespace Shop.Web.Components.PagesComponents
{
    public partial class RedirectToHomeComponent
    {
        [Inject] public NavigationManager NavigationManager { get; set; } = null!;

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                NavigationManager.NavigateTo("/", true);
            }
        }
    }
}
