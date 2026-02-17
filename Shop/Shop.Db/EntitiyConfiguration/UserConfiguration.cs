using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Db.Entities;

namespace Shop.Db.EntitiyConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Name).IsRequired();
            builder.Property(_ => _.Email).IsRequired();
            builder.Property(_ => _.PasswordHash).IsRequired();
            builder.Property(_ => _.Role).IsRequired();
            builder.Property(_ => _.Money)
                .IsRequired()
                .HasPrecision(18, 2)
                .HasDefaultValue(0m);
        }
    }
}
