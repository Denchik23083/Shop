using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Db.Entities;

namespace Shop.Db.EntitiyConfiguration
{
    public class BalanceConfiguration : IEntityTypeConfiguration<Balance>
    {
        public void Configure(EntityTypeBuilder<Balance> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Money)
                .HasPrecision(18, 2)
                .IsRequired();
            builder.Property(_ => _.TotalIncome)
                .HasPrecision(18, 2)
                .IsRequired();
            builder.Property(_ => _.TotalExpense)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(_ => _.UpdatedAtUtc);

            builder.HasData(new Balance
            {
                Id = 1,
                Money = 33000m,
                TotalIncome = 0m,
                TotalExpense = 0m,
            });
        }
    }
}
