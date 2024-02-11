using Domain.Entities;

namespace Application.Abstractions.Services.ShopServices;

public interface IProductHandlerService
{
    Task<Dictionary<ProductCategory, int>> CalculateProductCountForEachCategory();
}