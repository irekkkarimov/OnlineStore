using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class PromoCodeRepository : IPromoCodeRepository
{
    private readonly OnlineStoreDbContext _context;

    public PromoCodeRepository(OnlineStoreDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(PromoCode promoCode)
    {
        await _context.AddAsync(promoCode);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Update(PromoCode promoCode)
    {
        var promoCodeFromDb = await _context.PromoCodes
            .FirstOrDefaultAsync(i => i.Id == promoCode.Id);

        if (promoCodeFromDb is null)
            return false;

        _context.Update(promoCode);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemoveAsync(PromoCode promoCode)
    {
        _context.Remove(promoCode);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<PromoCode>> GetAllAsync()
    {
        return await _context.PromoCodes.ToListAsync();
    }

    public async Task<PromoCode?> GetByIdAsync(int id)
    {
        return await _context.PromoCodes.FirstOrDefaultAsync(i => i.Id == id);
    }
}