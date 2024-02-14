using Application.Abstractions.Services.ShopServices;
using Application.Abstractions.Services.ShopServices.HandlerServices;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Services.ShopServices.HandlerServices;

public class ProductHandlerService : IProductHandlerService
{
    private readonly IProductRepository _productRepository;

    public ProductHandlerService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Dictionary<ProductCategory, int>> CalculateProductCountForEachCategory()
    {
        var allProducts = await _productRepository.GetAllAsync();
        
        var allProductGroupsList = allProducts
            .Where(i => i.Category != null)
            .GroupBy(i => i.Category)
            .Where(i => i.Key != null)
            .ToList();

        var groupObjList = allProductGroupsList.Select(i => new { i.Key, Count = i.Count() })
            .ToList();
        
        var dict = groupObjList
            .ToDictionary(group => group.Key!, group => group.Count);

        return dict;
    }
}