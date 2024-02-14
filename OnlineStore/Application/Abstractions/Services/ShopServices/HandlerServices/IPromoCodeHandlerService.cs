using Application.DTOs.PromoCode;

namespace Application.Abstractions.Services.ShopServices.HandlerServices;

public interface IPromoCodeHandlerService
{
    Task Create(PromoCodeAddDto promoCodeAddDto);
    Task<bool> Activate(int id);
    Task<bool> Activate(string code);
    Task<bool> Deactivate(int id);
    Task<bool> Deactivate(string code);
    Task<bool> TryUse(string code, out double discount);
}