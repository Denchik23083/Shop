using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Db.Entities;

namespace Shop.Db.EntitiyConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Name).IsRequired();
            builder.Property(_ => _.Image).IsRequired();

            builder.HasData(
                new List<Category>
                {
                    new()
                    {
                        Id = 1,
                        Name = "Крупы",
                        Image = "img/categories/крупы.jpg"
                    },
                    new()
                    {
                        Id = 2,
                        Name = "Мучное",
                        Image = "img/categories/мучное.jpg"
                    },
                    new()
                    {
                        Id = 3,
                        Name = "Овощи",
                        Image = "img/categories/овощи.jpg"
                    },
                    new()
                    {
                        Id = 4,
                        Name = "Фрукты и ягоды",
                        Image = "img/categories/фрукты.jpg"
                    },
                    new()
                    {
                        Id = 5,
                        Name = "Молочные продукты",
                        Image = "img/categories/молочные_продукты.jpg"
                    },
                    new()
                    {
                        Id = 6,
                        Name = "Белковые продукты",
                        Image = "img/categories/белковые_продукты.jpg"
                    },
                    new()
                    {
                        Id = 7,
                        Name = "Алкоголь",
                        Image = "img/categories/алкоголь.jpg"
                    }
                }
            );
        }
    }
}
