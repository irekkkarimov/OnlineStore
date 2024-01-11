using Application.Abstractions.Services;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ProductHandlerService : IProductHandlerService
{
    private readonly IProductRepository;

    public ProductHandlerService(OnlineStoreDbContext context)
    {
        _context = context;
    }

    public async Task<Dictionary<ProductCategory, int>> CalculateProductCountForEachCategory()
    {
        var allProductGroupsList = await _context.Products
            .Where(i => i.Category != null)
            .GroupBy(i => i.Category)
            .Where(i => i.Key != null)
            .ToListAsync();

        var groupObjList = allProductGroupsList.Select(i => new { i.Key, Count = i.Count() })
            .ToList();
        
        var dict = groupObjList
            .ToDictionary(group => group.Key!, group => group.Count);

        return dict;
    }
}