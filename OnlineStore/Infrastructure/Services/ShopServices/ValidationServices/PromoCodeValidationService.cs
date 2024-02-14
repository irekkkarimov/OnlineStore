using Application.Abstractions.CustomExceptions.PromoCode;
using Application.Abstractions.Services.ShopServices.ValidationServices;
using Application.DTOs.PromoCode;

namespace Infrastructure.Services.ShopServices.ValidationServices;

public class PromoCodeValidationService : IPromoCodeValidationService
{
    public void ValidateAdding(PromoCodeAddDto promoCodeAddDto)
    {
        ValidateCode(promoCodeAddDto.Code);
        ValidateDiscount(promoCodeAddDto.Discount);
        ValidateLimit(promoCodeAddDto.LimitOfUsages);
        ValidateTime(promoCodeAddDto.TimeNotParsed);
    }

    private void ValidateCode(string code)
    {
        if (string.IsNullOrEmpty(code) || string.IsNullOrWhiteSpace(code))
            throw new InvalidPromoCodeException($"Invalid code");
    }

    private void ValidateDiscount(double discount)
    {
        if (discount is <= 0 or > 1)
            throw new InvalidPromoCodeException($"Invalid discount '{discount}'");
    }

    private void ValidateLimit(int limitOfUsages)
    {
        if (limitOfUsages <= 0)
            throw new InvalidPromoCodeException($"Invalid limit '{limitOfUsages}'");
    }

    private void ValidateTime(string timeNotParsed)
    {
        var allowedCharacters = new char[]
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'h', 'd', 'm', 'y', ' '
        };

        if (string.IsNullOrEmpty(timeNotParsed) || string.IsNullOrWhiteSpace(timeNotParsed))
            throw new InvalidPromoCodeException("Invalid time");

        if (timeNotParsed.Any(i => !allowedCharacters.Contains(i)))
            throw new InvalidPromoCodeException("");
    }
}