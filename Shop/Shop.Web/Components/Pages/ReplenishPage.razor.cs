using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Shop.Db.Entities;
using Shop.Services.CardService;
using System.Security.Claims;

namespace Shop.Web.Components.Pages
{
    public partial class ReplenishPage
    {
        [Inject] public ICardService Service { get; set; } = null!;

        [Inject] public AuthenticationStateProvider AuthStateProvider { get; set; } = null!;

        private Card? Card { get; set; }

        private bool _isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            _isLoading = true;
            StateHasChanged();

            var state = await AuthStateProvider.GetAuthenticationStateAsync();

            var userStrId = state.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userStrId, out var userId))
            {
                Card = null;
                await Task.Delay(1000);

                _isLoading = false;

                return;
            }

            Card = await Service.GetCardUserAsync(userId);

            await Task.Delay(1000);

            _isLoading = false;
        }
    }
}
