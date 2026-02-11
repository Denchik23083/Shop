using Shop.Data.CardRepository;
using Shop.Db.Entities;

namespace Shop.Services.CardService
{
    public class CardService(ICardRepository repository) : ICardService
    {
        private readonly ICardRepository _repository = repository;

        public async Task<Card?> GetCardAsync(int userId)
        {
            return await _repository.GetCardAsync(userId);
        }
    }
}
