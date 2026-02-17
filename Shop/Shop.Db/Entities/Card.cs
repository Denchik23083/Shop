using Shop.Contracts.Utilities;

namespace Shop.Db.Entities
{
    public class Card
    {
        public int Id { get; set; }

        public required string CardHolderName { get; set; }

        public required string CardNumber { get; set; }

        public required string Cvv { get; set; }

        public CardBrand Brand { get; set; }

        public int ExpMonth { get; set; }

        public int ExpYear { get; set; }

        public int UserId { get; set; }
    }
}
