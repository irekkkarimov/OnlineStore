using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance;

public class OnlineStoreDbContext : DbContext
{
    public OnlineStoreDbContext()
    {
        
    }
    
    public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OnlineStoreDbContext).Assembly);
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
}