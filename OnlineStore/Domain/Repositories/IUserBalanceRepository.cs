using Domain.Entities;

namespace Domain.Repositories;

public interface IUserBalanceRepository
{
    Task<bool> AddAsync(UserBalance userBalance);   
    Task<bool> RemoveAsync(UserBalance userBalance);
    Task<bool> UpdateAsync(UserBalance userBalance);
    Task<List<UserBalance>> GetAllAsync();
    Task<UserBalance?> GetByIdAsync(int id);
    Task<UserBalance?> GetByUserIdAsync(int userId);
}