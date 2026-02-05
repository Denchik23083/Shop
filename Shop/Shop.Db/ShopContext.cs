using Microsoft.EntityFrameworkCore;
using Shop.Db.Entities;

namespace Shop.Db
{
    public class ShopContext(DbContextOptions<ShopContext> options): DbContext(options)
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
