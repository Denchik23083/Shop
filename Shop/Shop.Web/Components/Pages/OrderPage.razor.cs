
using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;
using Shop.Services.OrderService;

namespace Shop.Web.Components.Pages
{
    public partial class OrderPage
    {
        [Inject] public IOrderService Service { get; set; } = null!;

        private Order? Order { get; set; }

        private decimal Total => Order?.OrderProducts
            .Sum(x => x.UnitPrice * x.Quantity) ?? 0m;

        protected override async Task OnInitializedAsync()
        {
            //TODO: by UserId
            Order = await Service.GetOrder(1);
        }
    }
}
