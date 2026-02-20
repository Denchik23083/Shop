using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;

namespace Shop.Web.Components.PagesComponents
{
    public partial class UsersComponent
    {
        [Parameter] public IEnumerable<User> Users { get; set; } = [];
                
        [Inject] public NavigationManager NavigationManager { get; set; } = null!;

        private bool _isShowMessage;
        private bool _isSuccess;
        private string _messageText = "";
    }
}
