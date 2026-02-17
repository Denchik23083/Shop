using Microsoft.EntityFrameworkCore;
using Shop.Db.Entities;

namespace Shop.Db
{
    public class ShopContext(DbContextOptions<ShopContext> options): DbContext(options)
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Order> Orders { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }

        public DbSet<Balance> Balances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
