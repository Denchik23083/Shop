using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;

namespace Shop.Web.Components.PagesComponents
{
    public partial class FilterUsersComponent
    {
        [Parameter] public IEnumerable<User> Users { get; set; } = [];

        private string _search = string.Empty;

        private IEnumerable<User> FilteredUsers =>
            string.IsNullOrWhiteSpace(_search) 
            ? Users
            : Users.Where(_ => 
            (!string.IsNullOrWhiteSpace(_.Name) && _.Name.StartsWith(_search, StringComparison.OrdinalIgnoreCase)) 
            || (!string.IsNullOrWhiteSpace(_.Email) && _.Email.StartsWith(_search, StringComparison.OrdinalIgnoreCase)));
    }
}
