using Microsoft.EntityFrameworkCore;

namespace OrderService
{
    public class OrderDbContext : DbContext
    {
        public DbSet<OrderEntity> Orders { get; set; } = null!;

        public OrderDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=OrdersDb;Username=postgres;Password=0000");
        }
    }
}
