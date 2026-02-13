using AutoMapper;
using Shop.Contracts.Models;
using Shop.Data.CardRepository;
using Shop.Data.DbContextScopeFactory;
using Shop.Data.UserRepository;
using Shop.Db.Entities;

namespace Shop.Services.CardService
{
    public class CardService(ICardRepository repository,
            IUserRepository userRepository,
            IDbContextScopeFactory dbContextScopeFactory,
            IMapper mapper) : ICardService
    {
        private readonly ICardRepository _repository = repository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IDbContextScopeFactory _dbContextScopeFactory = dbContextScopeFactory;
        private readonly IMapper _mapper = mapper;

        public async Task<Card?> GetCardUserAsync(int userId)
        {
            return await _repository.GetCardUserAsync(userId);
        }

        public async Task<bool> ReplenishAsync(decimal deposit, int userId)
        {
            await using var context = await _dbContextScopeFactory.GetSingleDbContextAsync();

            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                var user = await _userRepository.GetUserAsync(context, userId);

                if (user is null)
                {
                    return false;
                }

                user.Money += deposit;

                await _dbContextScopeFactory.SaveChangesAsync(context);
                await transaction.CommitAsync();

                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
        }

        public async Task<bool> SaveCardAsync(CardModel cardModel, int userId)
        {
            var mappedCard = _mapper.Map<Card>(cardModel);

            if (mappedCard is null)
            {
                return false;
            }

            mappedCard.UserId = userId;

            await _repository.SaveCardAsync(mappedCard);
            
            return true;
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
