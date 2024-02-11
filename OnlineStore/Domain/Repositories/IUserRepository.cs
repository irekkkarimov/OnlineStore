using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<bool> AddAsync(User user);
    Task<bool> UpdateAsync(User user);
    Task<bool> RemoveAsync(User user);
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
}