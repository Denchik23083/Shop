using System.ComponentModel.DataAnnotations;

namespace Shop.Contracts.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Не правильный Email формат")]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
