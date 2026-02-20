using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;

namespace Shop.Web.Components.PagesComponents
{
    public partial class FilterProductsComponent
    {
        [Parameter] public IEnumerable<Product> Products { get; set; } = [];

        private string _search = string.Empty;

        private IEnumerable<Product> FilteredProducts =>
            string.IsNullOrWhiteSpace(_search) 
            ? Products
            : Products.Where(_ => !string.IsNullOrWhiteSpace(_.Name) &&
                _.Name.StartsWith(_search, StringComparison.OrdinalIgnoreCase));
    }
}
