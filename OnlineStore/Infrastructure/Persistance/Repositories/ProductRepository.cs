using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly OnlineStoreDbContext _context;

    public ProductRepository(OnlineStoreDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Add(Product product)
    { 
        await _context.AddAsync(product);
        await _context.SaveChangesAsync();
        
        return true;
    }

    public async Task<bool> Update(Product product)
    {
        var oldProduct = await _context.Products.FirstOrDefaultAsync(i => i.Id == product.Id);

        if (oldProduct is null)
            return false;

        _context.Update(product);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Remove(Product product)
    {
        _context.Remove(product);
        await _context.SaveChangesAsync();
        
        return true;
    }

    public async Task<List<Product>> GetAll()
    {
        var products = _context.Products;
        return await products.ToListAsync();
    }

    public async Task<Product?> GetById(int id)
    {
        var productQuery = _context.Products.FirstOrDefaultAsync(i => i.Id == id);

        return await productQuery;
    }
}