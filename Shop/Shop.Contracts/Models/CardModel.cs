using Shop.Contracts.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Shop.Contracts.Models
{
    public class CardModel
    {
        [Required(ErrorMessage = "Введите имя на карте")]
        [RegularExpression(@"^[a-zA-Zа-яА-ЯёЁ\s]+$", ErrorMessage = "Неправильное имя")]
        public string CardHolderName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите номер карты")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Номер карты должен содержать ровно 16 цифр")]
        public string CardNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите cvv")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Cvv должен содержать ровно 3 цифры")]
        public string Cvv { get; set; } = string.Empty;

        public CardBrand Brand { get; set; } = CardBrand.Mastercard;

        public int ExpMonth { get; set; } = DateTime.UtcNow.Month;

        public int ExpYear { get; set; } = DateTime.UtcNow.Year % 100;
    }
}
