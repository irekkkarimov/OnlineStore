using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class PurchaseRepository : IPurchaseRepository
{
    private readonly OnlineStoreDbContext _context;

    public PurchaseRepository(OnlineStoreDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(Purchase purchase)
    {
        await _context.AddAsync(purchase);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemoveAsync(Purchase purchase)
    {
        _context.Remove(purchase);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<Purchase>> GetAllAsync()
    {
        var allPurchasesQuery = _context.Purchases
            .Include(i => i.User)
            .Include(i => i.Product);
        
        return await allPurchasesQuery.ToListAsync();
    }

    public async Task<Purchase?> GetByIdAsync(int id)
    {
        var purchaseQuery = _context.Purchases.FirstOrDefaultAsync(i => i.Id == id);

        return await purchaseQuery;
    }

    public async Task<List<Purchase>> GetAllByUserIdAsync(int userId)
    {
        var userPurchasesQuery = _context.Purchases.Where(i => i.UserId == userId);

        return await userPurchasesQuery.ToListAsync();
    }
}