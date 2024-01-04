using Domain.Entities;

namespace Application.Abstractions.Services;

public interface IProductHandlerSerivce
{
    Task<Dictionary<ProductCategory, int>> CalculateProductCountForEachCategory();
}