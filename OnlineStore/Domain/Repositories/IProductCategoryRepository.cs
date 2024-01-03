using Domain.Entities;

namespace Domain.Repositories;

public interface IProductCategoryRepository
{
    Task<bool> Add(ProductCategory productCategory);
    Task<bool> Update(ProductCategory productCategory);
    Task<bool> Remove(ProductCategory productCategory);
    Task<List<ProductCategory>> GetAll();
    Task<ProductCategory> GetById(int id);
}