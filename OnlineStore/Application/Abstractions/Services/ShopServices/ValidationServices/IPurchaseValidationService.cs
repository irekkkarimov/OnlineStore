using Application.DTOs.Purchase;

namespace Application.Abstractions.Services.ShopServices.ValidationServices;

public interface IPurchaseValidationService
{
    Task ValidateGettingByUserIdAsync(int userId);
    Task ValidateAddingAsync(PurchaseAddDto purchaseAddDto);
}