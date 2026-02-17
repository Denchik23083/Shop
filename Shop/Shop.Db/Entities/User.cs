namespace Shop.Db.Entities
{
    public class User
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string PasswordHash { get; set; }

        public decimal Money { get; set; }

        public required string Role { get; set; }

        public Order? Order { get; set; }

        public Card? Card { get; set; }
    }
}
