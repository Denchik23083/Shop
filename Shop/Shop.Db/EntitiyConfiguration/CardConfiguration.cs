using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Db.Entities;

namespace Shop.Db.EntitiyConfiguration
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.CardNumber)
                .HasMaxLength(16)
                .IsRequired();

            builder.Property(_ => _.Cvv)
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(_ => _.ExpMonth).IsRequired();
            builder.Property(_ => _.ExpYear).IsRequired();

            builder.HasIndex(o => o.UserId).IsUnique();

            builder.HasOne<User>()
                .WithOne(_ => _.Card)
                .HasForeignKey<Card>(_ => _.UserId);
        }
    }
}
