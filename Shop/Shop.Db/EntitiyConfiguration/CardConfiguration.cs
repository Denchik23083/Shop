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

            builder.Property(_ => _.CardHolderName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(_ => _.CardNumber)
                .HasMaxLength(16)
                .IsRequired();

            builder.ToTable(t => t.HasCheckConstraint("CK_CardNumber_Length", "LEN(CardNumber) = 16"));

            builder.Property(_ => _.Cvv)
                .HasMaxLength(3)
                .IsRequired();

            builder.ToTable(t => t.HasCheckConstraint("CK_Cvv_Length", "LEN(Cvv) = 3"));

            builder.Property(_ => _.Brand).HasConversion<int>();

            builder.Property(_ => _.ExpMonth).IsRequired();
            builder.Property(_ => _.ExpYear).IsRequired();

            builder.HasIndex(o => o.UserId).IsUnique();

            builder.HasOne<User>()
                .WithOne(_ => _.Card)
                .HasForeignKey<Card>(_ => _.UserId);
        }
    }
}
