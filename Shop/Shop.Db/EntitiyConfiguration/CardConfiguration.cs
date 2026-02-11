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

            builder.HasIndex(o => o.UserId).IsUnique();

            builder.HasOne<User>()
                .WithOne(_ => _.Card)
                .HasForeignKey<Card>(_ => _.UserId);
        }
    }
}
