using Domain.Entities;

namespace Domain.Repositories;

public interface IPurchaseRepository
{
    Task<bool> AddAsync(Purchase purchase);
    Task<bool> RemoveAsync(Purchase purchase);
    Task<List<Purchase>> GetAllAsync();
    Task<Purchase?> GetByIdAsync(int id);
    Task<List<Purchase>> GetAllByUserIdAsync(int id);
}