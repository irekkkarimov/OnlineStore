using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

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
        modelBuilder.Entity<CartItem>().Ignore(i => i.Id)
            .HasKey(i => new { i.UserId, i.ProductId });

        modelBuilder.Entity<UserBalance>().Ignore(i => i.Id)
            .HasKey(i => i.UserId);
            

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OnlineStoreDbContext).Assembly);
    }

    public DbSet<Product> Products { get; init; }
    public DbSet<ProductCategory> ProductCategories { get; init; }
    public DbSet<User> Users { get; init; }
    public DbSet<CartItem> CartItems { get; init; }
    public DbSet<Purchase> Purchases { get; init; }
    public DbSet<PromoCode> PromoCodes { get; init; }
    public DbSet<Session> Sessions { get; init; }
    public DbSet<UserBalance> UserBalances { get; init; }
}