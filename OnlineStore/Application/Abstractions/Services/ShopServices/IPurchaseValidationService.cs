using Application.DTOs.Purchase;

namespace Application.Abstractions.Services.ShopServices;

public interface IPurchaseValidationService
{
    Task ValidateAddingAsync(PurchaseAddDto purchaseAddDto);
}