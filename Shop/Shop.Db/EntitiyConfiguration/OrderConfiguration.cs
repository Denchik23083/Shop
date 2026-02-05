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

            builder.HasOne<User>()
                .WithMany(_ => _.Orders)
                .HasForeignKey(_ => _.UserId);
        }
    }
}
