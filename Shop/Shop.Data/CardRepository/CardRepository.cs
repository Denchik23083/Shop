using Microsoft.EntityFrameworkCore;
using Shop.Db;
using Shop.Db.Entities;

namespace Shop.Data.CardRepository
{
    public class CardRepository(IDbContextFactory<ShopContext> factory) : ICardRepository
    {
        private readonly IDbContextFactory<ShopContext> _factory = factory;

        public async Task<Card?> GetCardAsync(int cardId)
        {
            await using var context = await _factory.CreateDbContextAsync();

            return await context.Cards.FirstOrDefaultAsync(_ => _.Id == cardId);
        }

        public async Task<Card?> GetCardUserAsync(int userId)
        {
            await using var context = await _factory.CreateDbContextAsync();

            return await context.Cards.FirstOrDefaultAsync(_ => _.UserId == userId);
        }

        public async Task RemoveCardAsync(Card cardToRemove)
        {
            await using var context = await _factory.CreateDbContextAsync();

            context.Cards.Remove(cardToRemove);
            await context.SaveChangesAsync();
        }
    }
}
