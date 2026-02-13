using Shop.Contracts.Models;

namespace Shop.Web.Components.PagesComponents
{
    public partial class AddCardComponent
    {
        private CardModel CardModel = new();

        private List<int> Months = [.. Enumerable.Range(1, 12)];
        private List<int> Years = [.. Enumerable.Range(DateTime.UtcNow.Year % 100, 12)];

        public async Task SaveCard()
        {
        }
    }
}
