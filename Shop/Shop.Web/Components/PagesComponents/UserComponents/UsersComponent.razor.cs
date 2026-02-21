using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;

namespace Shop.Web.Components.PagesComponents.UserComponents
{
    public partial class UsersComponent
    {
        [Parameter] public IEnumerable<User> Users { get; set; } = [];
                
        private bool _isUserToAdminOpen;
        private bool _isDeleteUserOpen;
        private User? _user;

        private void OpenUserToAdminModal(User item)
        {
            _user = item;
            _isDeleteUserOpen = false;
            _isUserToAdminOpen = true;
        }

        private void OpenDeleteUserModal(User item)
        {
            _user = item;
            _isUserToAdminOpen = false;
            _isDeleteUserOpen = true;
        }
    }
}
