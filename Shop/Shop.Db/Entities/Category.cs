namespace Shop.Db.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Image { get; set; }

        public List<Product> Products { get; set; } = [];
    }
}
