using Application.DTOs.PromoCode;

namespace Application.Abstractions.Services.ShopServices.ValidationServices;

public interface IPromoCodeValidationService
{
    void ValidateAdding(PromoCodeAddDto promoCodeAddDto);
}