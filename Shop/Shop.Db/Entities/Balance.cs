namespace Shop.Db.Entities
{
    public class Balance
    {
        public int Id { get; set; }

        public decimal Money { get; set; }

        public decimal TotalIncome { get; set; }

        public decimal TotalExpense { get; set; }

        public DateTime? UpdatedAtUtc { get; set; }
    }
}
