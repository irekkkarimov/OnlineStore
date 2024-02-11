using Domain.Entities;

namespace Domain.Repositories;

public interface IProductRepository
{
    Task<bool> AddAsync(Product product);
    Task<bool> UpdateAsync(Product product);
    Task<bool> RemoveAsync(Product product);
    Task<List<Product>> GetAllAsync();
    Task<List<Product>> GetAllByCategoryIdAsync(int categoryId);
    
    Task<Product?> GetByIdAsync(int id);
}