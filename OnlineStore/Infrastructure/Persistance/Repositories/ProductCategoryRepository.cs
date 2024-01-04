using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly OnlineStoreDbContext _context;

    public ProductCategoryRepository(OnlineStoreDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Add(ProductCategory productCategory)
    {
        await _context.AddAsync(productCategory);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Update(ProductCategory productCategory)
    {
        var oldProduct = await _context.Products.FirstOrDefaultAsync(i => i.Id == productCategory.Id);

        if (oldProduct is null)
            return false;

        _context.Update(productCategory);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Remove(ProductCategory productCategory)
    {
        _context.Remove(productCategory);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<ProductCategory>> GetAll()
    {
        var productCategories = _context.ProductCategories;
        return await productCategories.ToListAsync();
    }

    public async Task<ProductCategory?> GetById(int id)
    {
        var productCategoryQuery = _context.ProductCategories.FirstOrDefaultAsync(i => i.Id == id);

        return await productCategoryQuery;
    }
}