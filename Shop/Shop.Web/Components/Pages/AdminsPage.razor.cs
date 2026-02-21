using Microsoft.AspNetCore.Components;
using Shop.Contracts.Utilities;
using Shop.Db.Entities;
using Shop.Services.UserService;

namespace Shop.Web.Components.Pages
{
    public partial class AdminsPage
    {
        [Inject] public IUserService Service { get; set; } = null!;

        private IEnumerable<User> Admins = [];

        protected override async Task OnInitializedAsync()
        {
            Admins = await Service.GetAllUsersByRoleAsync(RoleType.Admin);
        }
    }
}
