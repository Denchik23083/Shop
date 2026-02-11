using Shop.Db.Entities;

namespace Shop.Data.CardRepository
{
    public interface ICardRepository
    {
        Task<Card?> GetCardAsync(int userId);
    }
}