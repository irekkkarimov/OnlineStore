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

    public async Task<bool> AddAsync(Product product)
    { 
        await _context.AddAsync(product);
        await _context.SaveChangesAsync();
        
        return true;
    }

    public async Task<bool> UpdateAsync(Product product)
    {
        var oldProduct = await _context.Products.FirstOrDefaultAsync(i => i.Id == product.Id);

        if (oldProduct is null)
            return false;

        _context.Update(product);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemoveAsync(Product product)
    {
        _context.Remove(product);
        await _context.SaveChangesAsync();
        
        return true;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        var products = _context.Products.Include(i => i.Category);
        return await products.ToListAsync();
    }

    public async Task<List<Product>> GetAllByCategoryIdAsync(int categoryId)
    {
        var productsByCategoryId = _context.Products.Where(i => i.CategoryId == categoryId)
            .Include(i => i.Category);
        return await productsByCategoryId.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        var productQuery = _context.Products.Include(i => i.Category).FirstOrDefaultAsync(i => i.Id == id);

        return await productQuery;
    }
}