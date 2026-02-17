namespace Shop.Db.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Image { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal Price { get; set; }

        public DateTime Expiration { get; set; }

        public int Count { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }
        
        public List<OrderProduct> OrderProducts { get; set; } = [];
    }
}
