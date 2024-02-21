using Application.Abstractions.Services.UserServices;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class UserBalanceRepository : IUserBalanceRepository
{
    private readonly OnlineStoreDbContext _context;

    public UserBalanceRepository(OnlineStoreDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(UserBalance userBalance)
    {
        await _context.AddAsync(userBalance);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemoveAsync(UserBalance userBalance)
    {
        _context.Remove(userBalance);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(UserBalance userBalance)
    {
        var userBalanceFromDb = _context.UserBalances
            .FirstOrDefault(i => i.UserId == userBalance.UserId);

        if (userBalanceFromDb is null)
            return false;

        userBalanceFromDb.Balance = userBalance.Balance;
        userBalanceFromDb.ModifiedAt = userBalance.ModifiedAt;
        _context.Update(userBalanceFromDb);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<UserBalance>> GetAllAsync()
    {
        return await _context.UserBalances
            .Include(i => i.User)
            .ToListAsync();
    }

    public async Task<UserBalance?> GetByIdAsync(int id)
    {
        return await _context.UserBalances
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<UserBalance?> GetByUserIdAsync(int userId)
    {
        return await _context.UserBalances
            .FirstOrDefaultAsync(i => i.UserId == userId);
    }
}