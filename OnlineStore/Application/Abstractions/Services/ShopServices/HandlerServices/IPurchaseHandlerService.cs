using Application.Abstractions.CustomExceptions.Abstractions.Purchase;
using Application.DTOs.Purchase;

namespace Application.Abstractions.Services.ShopServices.HandlerServices;

public interface IPurchaseHandlerService
{
    /// <summary>
    /// Makes a purchase
    /// </summary>
    /// <param name="purchaseAddDto">A DTO to make a purchase</param>
    /// <returns><see cref="PurchaseResultDto"/> containing information about the purchase</returns>
    /// <exception cref="InvalidPurchaseException">Total price was less than 0</exception>
    Task<PurchaseResultDto> MakePurchaseAsync(PurchaseAddDto purchaseAddDto);
}