using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class SessionRepository : ISessionRepository
{
    private readonly OnlineStoreDbContext _context;

    public SessionRepository(OnlineStoreDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(Session session)
    {
        await _context.Sessions.AddAsync(session);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemoveAsync(Session session)
    {
        _context.Remove(session);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<Session>> GetAllAsync()
    {
        return await _context.Sessions
            .Include(i => i.User)
            .ToListAsync();
    }

    public async Task<Session?> GetByIdAsync(int id)
    {
        return await _context.Sessions.FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<List<Session>> GetAllByUserIdAsync(int userId)
    {
        return await _context.Sessions
            .Where(i => i.UserId == userId)
            .ToListAsync();
    }

    public async Task<Session?> GetLastByUserIdAsync(int userId)
    {
        return await _context.Sessions
            .Where(i => i.UserId == userId)
            .OrderByDescending(i => i.LoggedInAt)
            .FirstOrDefaultAsync();
    }
}