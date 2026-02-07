using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Db.Entities;

namespace Shop.Db.EntitiyConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.CreatedAt);
            builder.HasIndex(o => o.UserId).IsUnique();

            builder.HasOne<User>()
                .WithOne(_ => _.Order)
                .HasForeignKey<Order>(_ => _.UserId);
        }
    }
}
