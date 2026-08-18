using Microsoft.EntityFrameworkCore;
using Invoice_System.Model;

namespace Invoice_System.Data
{
     public class AppDbContext : DbContext
     {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

     }
}
