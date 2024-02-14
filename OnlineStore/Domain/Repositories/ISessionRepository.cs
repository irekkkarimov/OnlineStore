using Domain.Entities;

namespace Domain.Repositories;

public interface ISessionRepository
{
    Task<bool> AddAsync(Session session);
    Task<bool> RemoveAsync(Session session);
    Task<List<Session>> GetAllAsync();
    Task<Session?> GetByIdAsync(int id);
    Task<List<Session>> GetAllByUserIdAsync(int userId);
    Task<Session?> GetLastByUserIdAsync(int userId);
}