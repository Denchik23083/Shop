using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;
using Shop.Services.UserService;

namespace Shop.Web.Components.Pages
{
    public partial class UsersPage
    {
        [Inject] public IUserService Service { get; set; } = null!;
        
        private IEnumerable<User> Users = [];

        protected override async Task OnInitializedAsync()
        {
            Users = await Service.GetAllUsersAsync();
        }
    }
}
