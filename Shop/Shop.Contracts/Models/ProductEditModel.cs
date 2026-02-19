using System.ComponentModel.DataAnnotations;

namespace Shop.Contracts.Models
{
    public class ProductEditModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal PurchasePrice { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
