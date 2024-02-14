using Domain.Entities;

namespace Domain.Repositories;

public interface IPromoCodeRepository
{
    Task<bool> AddAsync(PromoCode promoCode);
    Task<bool> Update(PromoCode promoCode);
    Task<bool> RemoveAsync(PromoCode promoCode);
    Task<List<PromoCode>> GetAllAsync();
    Task<PromoCode?> GetByIdAsync(int id);
}