using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Db.Entities;

namespace Shop.Db.EntitiyConfiguration
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Quantity);
            builder.Property(_ => _.UnitPrice).HasPrecision(18, 2);

            builder.HasOne(_ => _.Product)
                .WithMany(_ => _.OrderProducts)
                .HasForeignKey(_ => _.ProductId);

            builder.HasOne<Order>()
                .WithMany(_ => _.OrderProducts)
                .HasForeignKey(_ => _.OrderId);
        }
    }
}
