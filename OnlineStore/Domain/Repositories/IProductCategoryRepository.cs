using Domain.Entities;

namespace Domain.Repositories;

public interface IProductCategoryRepository
{
    Task<bool> AddAsync(ProductCategory productCategory);
    Task<bool> UpdateAsync(ProductCategory productCategory);
    Task<bool> RemoveAsync(ProductCategory productCategory);
    Task<List<ProductCategory>> GetAllAsync();
    Task<ProductCategory?> GetByIdAsync(int id);
}