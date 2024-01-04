using Domain.Entities;

namespace Domain.Repositories;

public interface IProductRepository
{
    Task<bool> Add(Product product);
    Task<bool> Update(Product product);
    Task<bool> Remove(Product product);
    Task<List<Product>> GetAll();
    Task<Product?> GetById(int id);
}