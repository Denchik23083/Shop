namespace Shop.Db.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public DateTime Expiration { get; set; }

        public List<OrderProduct> OrderProducts { get; set; } = [];
    }
}
