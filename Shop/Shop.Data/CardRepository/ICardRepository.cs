using Shop.Db.Entities;

namespace Shop.Data.CardRepository
{
    public interface ICardRepository
    {
        Task<Card?> GetCardAsync(int cardId);

        Task<Card?> GetCardUserAsync(int userId);

        Task RemoveCardAsync(Card cardToRemove);
    }
}