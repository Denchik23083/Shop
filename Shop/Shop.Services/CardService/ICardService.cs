using Shop.Contracts.Models;
using Shop.Db.Entities;

namespace Shop.Services.CardService
{
    public interface ICardService
    {
        Task<Card?> GetCardUserAsync(int userId);

        Task<bool> ReplenishAsync(decimal deposit, int userId);
        
        Task<bool> SaveCardAsync(CardModel cardModel, int userId);

        Task<bool> DeleteCardAsync(int cardId);
    }
}