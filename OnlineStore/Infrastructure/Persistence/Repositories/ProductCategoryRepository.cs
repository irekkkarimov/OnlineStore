using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly OnlineStoreDbContext _context;

    public ProductCategoryRepository(OnlineStoreDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(ProductCategory productCategory)
    {
        await _context.AddAsync(productCategory);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(ProductCategory productCategory)
    {
        var oldProduct = await _context.ProductCategories.FirstOrDefaultAsync(i => i.Id == productCategory.Id);
        Console.WriteLine("before");
        if (oldProduct is null)
            return false;
        
        Console.WriteLine("after");

        _context.Update(productCategory);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemoveAsync(ProductCategory productCategory)
    {
        _context.Remove(productCategory);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<ProductCategory>> GetAllAsync()
    {
        var productCategories = _context.ProductCategories;
        return await productCategories.ToListAsync();
    }

    public async Task<ProductCategory?> GetByIdAsync(int id)
    {
        var productCategoryQuery = _context.ProductCategories.FirstOrDefaultAsync(i => i.Id == id);

        return await productCategoryQuery;
    }
}