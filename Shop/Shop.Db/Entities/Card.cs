using Shop.Contracts.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Shop.Db.Entities
{
    public class Card
    {
        public int Id { get; set; }

        [MinLength(16)]
        public string CardNumber { get; set; } = string.Empty;

        [MinLength(3)]
        public string Cvv { get; set; } = string.Empty;

        public CardBrand Brand { get; set; }

        public int ExpMonth { get; set; }

        public int ExpYear { get; set; }

        public int UserId { get; set; }
    }
}
