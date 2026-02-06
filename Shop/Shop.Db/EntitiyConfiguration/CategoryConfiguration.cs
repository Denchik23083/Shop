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

            builder.Property(_ => _.Name);

            builder.HasData(
                new List<Category>
                {
                    new()
                    {
                        Id = 1,
                        Name = "Крупы",
                    },
                    new()
                    {
                        Id = 2,
                        Name = "Зерновые",
                    },
                    new()
                    {
                        Id = 3,
                        Name = "Овощи",
                    },
                    new()
                    {
                        Id = 4,
                        Name = "Фрукты и ягоды",
                    },
                    new()
                    {
                        Id = 5,
                        Name = "Молочные продукты",
                    },
                    new()
                    {
                        Id = 6,
                        Name = "Белковые продукты",
                    },
                    new()
                    {
                        Id = 7,
                        Name = "Другое",
                    },
                });
        }
    }
}
