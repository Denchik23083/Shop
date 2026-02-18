using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;
using Shop.Services.AdminService;

namespace Shop.Web.Components.Pages
{
    public partial class BalancePage
    {
        [Inject] public IAdminService Service { get; set; } = null!;

        private Balance? Balance { get; set; }

        private bool _isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            Balance = await Service.GetBalance();

            await Task.Delay(500);

            _isLoading = false;
        }
    }
}
