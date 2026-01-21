using Microsoft.EntityFrameworkCore;

namespace MiniGroceryApi.Models
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Product>().HasData(
        new Product { Id = 1, Name = "Rice", Price = 50, Stock = 100 },
        new Product { Id = 2, Name = "Wheat", Price = 40, Stock = 80 },
        new Product { Id = 3, Name = "Sugar", Price = 30, Stock = 60 }
      );
    }
  }
}