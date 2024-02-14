using Domain.Entities;

namespace Application.Abstractions.Services.ShopServices.HandlerServices;

public interface IProductHandlerService
{
    Task<Dictionary<ProductCategory, int>> CalculateProductCountForEachCategory();
}