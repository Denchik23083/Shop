using Shop.Db.Entities;

namespace Shop.Services.CardService
{
    public interface ICardService
    {
        Task<Card?> GetCardUserAsync(int userId);

        Task<bool> RemoveCardAsync(int cardId);
    }
}