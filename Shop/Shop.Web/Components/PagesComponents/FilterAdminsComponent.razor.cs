using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;

namespace Shop.Web.Components.PagesComponents
{
    public partial class FilterAdminsComponent
    {
        [Parameter] public IEnumerable<User> Admins { get; set; } = [];

        private string _search = string.Empty;

        private IEnumerable<User> FilteredAdmins =>
            string.IsNullOrWhiteSpace(_search)
            ? Admins
            : Admins.Where(_ =>
            (!string.IsNullOrWhiteSpace(_.Name) && _.Name.StartsWith(_search, StringComparison.OrdinalIgnoreCase))
            || (!string.IsNullOrWhiteSpace(_.Email) && _.Email.StartsWith(_search, StringComparison.OrdinalIgnoreCase)));
    }
}
