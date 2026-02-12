using Shop.Data.CardRepository;
using Shop.Db.Entities;

namespace Shop.Services.CardService
{
    public class CardService(ICardRepository repository) : ICardService
    {
        private readonly ICardRepository _repository = repository;

        public async Task<Card?> GetCardUserAsync(int userId)
        {
            return await _repository.GetCardUserAsync(userId);
        }

        public async Task<bool> RemoveCardAsync(int cardId)
        {
            var cardToRemove = await _repository.GetCardAsync(cardId);

            if (cardToRemove is null)
            {
                return false;
            }

            await _repository.RemoveCardAsync(cardToRemove);

            return true;
        }
    }
}
