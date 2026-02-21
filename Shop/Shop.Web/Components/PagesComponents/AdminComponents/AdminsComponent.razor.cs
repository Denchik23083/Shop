using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;

namespace Shop.Web.Components.PagesComponents.AdminComponents
{
    public partial class AdminsComponent
    {
        [Parameter] public IEnumerable<User> Admins { get; set; } = [];

        private bool _isAdminToUserOpen;
        private User? _admin;

        private void OpenUserToAdminModal(User item)
        {
            _admin = item;
            _isAdminToUserOpen = true;
        }
    }
}
