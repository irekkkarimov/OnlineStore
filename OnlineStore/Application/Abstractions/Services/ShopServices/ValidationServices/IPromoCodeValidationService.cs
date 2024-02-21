using Application.Abstractions.CustomExceptions.PromoCode;
using Application.DTOs.PromoCode;

namespace Application.Abstractions.Services.ShopServices.ValidationServices;

public interface IPromoCodeValidationService
{
    /// <summary>
    /// Validates adding a new PromoCode
    /// </summary>
    /// <param name="promoCodeAddDto">A DTO containing information about new PromoCode</param>
    /// <exception cref="InvalidPromoCodeException">Invalid code, discount, limit or time</exception>
    void ValidateAdding(PromoCodeAddDto promoCodeAddDto);
}