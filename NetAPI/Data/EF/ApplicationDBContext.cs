using NetAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace NetAPI.Data.EF
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
        }

        public DbSet<Account> Accounts { set; get; } = default!;
        public DbSet<Category> Categories { set; get; } = default!;
        public DbSet<Product> Products { set; get; } = default!;
        public DbSet<Customer> Customers { set; get; } = default!;
        public DbSet<Order> Orders { set; get; } = default!;
        public DbSet<OrderDetail> OrderDetails { set; get; } = default!;

    }
}