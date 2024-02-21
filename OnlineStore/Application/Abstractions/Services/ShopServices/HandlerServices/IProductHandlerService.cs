using Domain.Entities;

namespace Application.Abstractions.Services.ShopServices.HandlerServices;

public interface IProductHandlerService
{
    /// <summary>
    /// Calculates product count for each <see cref="ProductCategory"/>
    /// </summary>
    /// <returns>A <see cref="Dictionary{TKey,TValue}"/> representing
    /// a count of products for each <see cref="ProductCategory"/></returns>
    Task<Dictionary<ProductCategory, int>> CalculateProductCountForEachCategory();
}