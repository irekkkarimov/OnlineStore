using Domain.Entities;

namespace Application.Abstractions.Services;

public interface IProductHandlerService
{
    Task<Dictionary<ProductCategory, int>> CalculateProductCountForEachCategory();
}