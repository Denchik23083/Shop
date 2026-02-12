using Microsoft.AspNetCore.Components;
using Shop.Db.Entities;
using Shop.Services.CardService;

namespace Shop.Web.Components.PagesComponents
{
    public partial class AddCardComponent
    {
        [Parameter] public required Card Card { get; set; }

        [Inject] public ICardService Service { get; set; } = null!;

        [Inject] public NavigationManager NavigationManager { get; set; } = null!;

        private bool _isShowMessage;
        private bool _isSuccess;
        private string _messageText = "";

        private string Number =>
            Card?.CardNumber.Substring(Card.CardNumber.Length - 4, 4) ?? "";

        private async Task Remove(int cardId)
        {
            var result = await Service.RemoveCardAsync(cardId);

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
    }
}
