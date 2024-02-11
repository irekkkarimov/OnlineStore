using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly OnlineStoreDbContext _context;

    public UserRepository(OnlineStoreDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(User user)
    {
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(User user)
    {
        var oldUser = await _context.Users.FirstOrDefaultAsync(i => i.Id == user.Id);

        if (oldUser is null)
            return false;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemoveAsync(User user)
    {
        _context.Remove(user);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<User>> GetAllAsync()
    {
        var users = _context.Users;
        return await users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var userQuery = _context.Users.FirstOrDefaultAsync(i => i.Id == id);
        return await userQuery;
    }
}