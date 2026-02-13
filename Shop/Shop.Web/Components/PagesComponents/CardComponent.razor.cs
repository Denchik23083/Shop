using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Shop.Db.Entities;
using Shop.Services.CardService;
using System.Security.Claims;

namespace Shop.Web.Components.PagesComponents
{
    public partial class CardComponent
    {
        [Parameter] public required Card Card { get; set; }

        [Inject] public ICardService Service { get; set; } = null!;

        [Inject] public AuthenticationStateProvider AuthStateProvider { get; set; } = null!;
        
        [Inject] public NavigationManager NavigationManager { get; set; } = null!;

        private bool _isShowMessage;
        private bool _isSuccess;
        private string _messageText = "";

        private decimal Deposit = 0m;

        private string Number =>
            Card?.CardNumber.Substring(Card.CardNumber.Length - 4, 4) ?? "";

        private async Task Remove()
        {
            var result = await Service.RemoveCardAsync(Card.Id);

            _isSuccess = result;
            _messageText = result
                ? "Карта удалена"
                : "Не удалось удалить карту";

            _isShowMessage = true;
            StateHasChanged();

            await Task.Delay(1500);

            _isShowMessage = false;
            StateHasChanged();

            if (result)
            {
                NavigationManager.NavigateTo("/replenish", true);
            }
        }

        private async Task Replenish()
        {
            var state = await AuthStateProvider.GetAuthenticationStateAsync();

            var userStrId = state.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userStrId, out var userId))
            {
                return;
            }

            var result = await Service.ReplenishAsync(Deposit, userId);

            await Task.Delay(1000);

            _isSuccess = result;
            _messageText = result
                ? "Средства зачислены"
                : "Не удалось пополнить балланс";

            _isShowMessage = true;
            StateHasChanged();

            await Task.Delay(1500);

            _isShowMessage = false;
            StateHasChanged();

            if (result)
            {
                NavigationManager.NavigateTo("/", true);
            }
        }
    }
}
