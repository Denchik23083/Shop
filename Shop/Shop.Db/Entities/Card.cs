using Shop.Contracts.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Shop.Db.Entities
{
    public class Card
    {
        public int Id { get; set; }

        public string CardHolderName { get; set; } = string.Empty;

        public string CardNumber { get; set; } = string.Empty;

        public string Cvv { get; set; } = string.Empty;

        public CardBrand Brand { get; set; }

        public int ExpMonth { get; set; }

        public int ExpYear { get; set; }

        public int UserId { get; set; }
    }
}
