using Labb2WebbTemplate.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace webbutveckling_labb2_Heimbrand.DB;

public class WebbHandelDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public WebbHandelDbContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderProduct>()
            .HasKey(op => new { op.OrderId, op.ProductId });

    }
}