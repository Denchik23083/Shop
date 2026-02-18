using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Shop.Contracts.Models;
using Shop.Services.CardService;
using System.Security.Claims;

namespace Shop.Web.Components.PagesComponents
{
    public partial class AddCardComponent
    {
        [Inject] public ICardService Service { get; set; } = null!;

        [Inject] public AuthenticationStateProvider AuthStateProvider { get; set; } = null!;

        [Inject] public NavigationManager NavigationManager { get; set; } = null!;

        private readonly List<int> Months = [.. Enumerable.Range(1, 12)];
        private readonly List<int> Years = [.. Enumerable.Range(DateTime.UtcNow.Year % 100, 12)];

        private readonly CardModel CardModel = new();
        private bool _isShowMessage;
        private bool _isSuccess;
        private string _messageText = "";

        public async Task SaveCard()
        {
            var state = await AuthStateProvider.GetAuthenticationStateAsync();

            var userStrId = state.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userStrId, out var userId))
            {
                return;
            }

            var result = await Service.SaveCardAsync(CardModel, userId);

            await Task.Delay(500);

            _isSuccess = result;
            _messageText = result
                ? "Карта сохранена"
                : "Не удалось сохранить карту";

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
