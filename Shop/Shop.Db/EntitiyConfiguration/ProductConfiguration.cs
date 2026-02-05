using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Db.Entities;

namespace Shop.Db.EntitiyConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Name);
            builder.Property(_ => _.Price).HasPrecision(18, 2);
            builder.Property(_ => _.Expiration);

            builder.HasData(
                new List<Product>
                {
                    new()
                    {
                        Id = 1,
                        Name = "Гречка",
                        Price = 100,
                        Count = 10,
                        Expiration = new DateTime(2026, 2, 12),
                    },
                    new()
                    {
                        Id = 2,
                        Name = "Молоко",
                        Price = 150,
                        Count = 20,
                        Expiration = new DateTime(2026, 2, 6)
                    },
                    new()
                    {
                        Id = 3,
                        Name = "Мясо",
                        Price = 300,
                        Count = 15,
                        Expiration = new DateTime(2026, 2, 8)
                    }
                });
        }
    }
}
