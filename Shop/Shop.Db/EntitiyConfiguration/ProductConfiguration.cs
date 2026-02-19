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

            builder.Property(_ => _.Name).IsRequired();
            builder.Property(_ => _.Image).IsRequired();
            builder.Property(_ => _.PurchasePrice).HasPrecision(18, 2);
            builder.Property(_ => _.Price).HasPrecision(18, 2);
            builder.Property(_ => _.Expiration);

            builder.HasOne(_ => _.Category)
                .WithMany(_ => _.Products)
                .HasForeignKey(_ => _.CategoryId);

            builder.HasData(
                new List<Product>
                {
                    new()
                    {
                        Id = 1,
                        Name = "Гречка",
                        Image = "img/products/гречка.jpg",
                        PurchasePrice = 50,
                        Price = 100,
                        Count = 40,
                        Expiration = new DateTime(2026, 3, 15),
                        CategoryId = 1
                    },
                    new()
                    {
                        Id = 2,
                        Name = "Рис",
                        Image = "img/products/рис.jpg",
                        PurchasePrice = 30,
                        Price = 50,
                        Count = 40,
                        Expiration = new DateTime(2026, 3, 15),
                        CategoryId = 1
                    },
                    new()
                    {
                        Id = 3,
                        Name = "Овсяка",
                        Image = "img/products/овсянка.jpg",
                        PurchasePrice = 20,
                        Price = 40,
                        Count = 40,
                        Expiration = new DateTime(2026, 3, 15),
                        CategoryId = 1
                    },
                    new()
                    {
                        Id = 4,
                        Name = "Хлеб белый",
                        Image = "img/products/хлеб_белый.jpg",
                        PurchasePrice = 20,
                        Price = 40,
                        Count = 30,
                        Expiration = new DateTime(2026, 2, 20),
                        CategoryId = 2
                    },
                    new()
                    {
                        Id = 5,
                        Name = "Хлеб черный",
                        Image = "img/products/хлеб_черный.jpg",
                        PurchasePrice = 20,
                        Price = 40,
                        Count = 30,
                        Expiration = new DateTime(2026, 2, 20),
                        CategoryId = 2
                    },
                    new()
                    {
                        Id = 6,
                        Name = "Булочки",
                        Image = "img/products/булочки.jpg",
                        PurchasePrice = 15,
                        Price = 30,
                        Count = 50,
                        Expiration = new DateTime(2026, 2, 20),
                        CategoryId = 2
                    },
                    new()
                    {
                        Id = 7,
                        Name = "Огурцы",
                        Image = "img/products/огурцы.jpg",
                        PurchasePrice = 20,
                        Price = 50,
                        Count = 30,
                        Expiration = new DateTime(2026, 2, 26),
                        CategoryId = 3
                    },
                    new()
                    {
                        Id = 8,
                        Name = "Помидоры",
                        Image = "img/products/помидоры.jpg",
                        PurchasePrice = 40,
                        Price = 70,
                        Count = 30,
                        Expiration = new DateTime(2026, 2, 26),
                        CategoryId = 3
                    },
                    new()
                    {
                        Id = 9,
                        Name = "Картошка",
                        Image = "img/products/картошка.jpg",
                        PurchasePrice = 20,
                        Price = 45,
                        Count = 50,
                        Expiration = new DateTime(2026, 3, 25),
                        CategoryId = 3
                    },
                    new()
                    {
                        Id = 10,
                        Name = "Лук",
                        Image = "img/products/лук.jpg",
                        PurchasePrice = 10,
                        Price = 25,
                        Count = 50,
                        Expiration = new DateTime(2026, 3, 22),
                        CategoryId = 3
                    },
                    new()
                    {
                        Id = 11,
                        Name = "Яблоки",
                        Image = "img/products/яблоки.jpg",
                        PurchasePrice = 20,
                        Price = 30,
                        Count = 40,
                        Expiration = new DateTime(2026, 2, 25),
                        CategoryId = 4
                    },
                    new()
                    {
                        Id = 12,
                        Name = "Бананы",
                        Image = "img/products/бананы.jpg",
                        PurchasePrice = 25,
                        Price = 45,
                        Count = 40,
                        Expiration = new DateTime(2026, 2, 20),
                        CategoryId = 4
                    },
                    new()
                    {
                        Id = 13,
                        Name = "Бананы",
                        Image = "img/products/бананы.jpg",
                        PurchasePrice = 25,
                        Price = 45,
                        Count = 40,
                        Expiration = new DateTime(2026, 2, 20),
                        CategoryId = 4
                    },
                    new()
                    {
                        Id = 14,
                        Name = "Мандарины",
                        Image = "img/products/мандарины.jpg",
                        PurchasePrice = 45,
                        Price = 70,
                        Count = 50,
                        Expiration = new DateTime(2026, 3, 1),
                        CategoryId = 4,
                    },
                    new()
                    {
                        Id = 15,
                        Name = "Виноград",
                        Image = "img/products/виноград.jpg",
                        PurchasePrice = 45,
                        Price = 70,
                        Count = 50,
                        Expiration = new DateTime(2026, 3, 14),
                        CategoryId = 4,
                    },
                    new()
                    {
                        Id = 16,
                        Name = "Молоко",
                        Image = "img/products/молоко.jpg",
                        PurchasePrice = 70,
                        Price = 150,
                        Count = 20,
                        Expiration = new DateTime(2026, 2, 18),
                        CategoryId = 5,
                    },
                    new()
                    {
                        Id = 17,
                        Name = "Творог",
                        Image = "img/products/творог.jpg",
                        PurchasePrice = 60,
                        Price = 120,
                        Count = 20,
                        Expiration = new DateTime(2026, 2, 20),
                        CategoryId = 5,
                    },
                    new()
                    {
                        Id = 18,
                        Name = "Сметана",
                        Image = "img/products/сметана.jpg",
                        PurchasePrice = 50,
                        Price = 100,
                        Count = 20,
                        Expiration = new DateTime(2026, 2, 20),
                        CategoryId = 5,
                    },
                    new()
                    {
                        Id = 19,
                        Name = "Сыр",
                        Image = "img/products/сыр.jpg",
                        PurchasePrice = 75,
                        Price = 150,
                        Count = 30,
                        Expiration = new DateTime(2026, 3, 1),
                        CategoryId = 5,
                    }, 
                    new()
                    {
                        Id = 20,
                        Name = "Курица",
                        Image = "img/products/курица.jpg",
                        PurchasePrice = 150,
                        Price = 250,
                        Count = 15,
                        Expiration = new DateTime(2026, 3, 1),
                        CategoryId = 6
                    },
                    new()
                    {
                        Id = 21,
                        Name = "Свинина",
                        Image = "img/products/свинина.jpg",
                        PurchasePrice = 200,
                        Price = 300,
                        Count = 15,
                        Expiration = new DateTime(2026, 3, 1),
                        CategoryId = 6
                    },
                    new()
                    {
                        Id = 22,
                        Name = "Рыба",
                        Image = "img/products/рыба.jpg",
                        PurchasePrice = 200,
                        Price = 300,
                        Count = 15,
                        Expiration = new DateTime(2026, 3, 1),
                        CategoryId = 6
                    },
                    new()
                    {
                        Id = 23,
                        Name = "Яйца",
                        Image = "img/products/яйца.jpg",
                        PurchasePrice = 50,
                        Price = 100,
                        Count = 200,
                        Expiration = new DateTime(2026, 3, 1),
                        CategoryId = 6
                    },
                    new()
                    {
                        Id = 24,
                        Name = "Вино",
                        Image = "img/products/вино.jpg",
                        PurchasePrice = 500,
                        Price = 1000,
                        Count = 20,
                        Expiration = new DateTime(2026, 4, 1),
                        CategoryId = 7
                    },
                    new()
                    {
                        Id = 25,
                        Name = "Шампанское",
                        Image = "img/products/шампанское.jpg",
                        PurchasePrice = 400,
                        Price = 800,
                        Count = 20,
                        Expiration = new DateTime(2026, 4, 1),
                        CategoryId = 7
                    },
                    new()
                    {
                        Id = 26,
                        Name = "Коньяк",
                        Image = "img/products/коньяк.jpg",
                        PurchasePrice = 700,
                        Price = 1500,
                        Count = 20,
                        Expiration = new DateTime(2026, 4, 1),
                        CategoryId = 7
                    }
                }
            );
        }
    }
}
