using Application.Abstractions.CustomExceptions.Abstractions.Purchase;
using Application.DTOs.Purchase;

namespace Application.Abstractions.Services.ShopServices.ValidationServices;

public interface IPurchaseValidationService
{
    /// <summary>
    /// Validates getting by UserId
    /// </summary>
    /// <param name="userId">id of User that Purchases belong to</param>
    /// <exception cref="InvalidPurchaseException">User was not found</exception>
    Task ValidateGettingByUserIdAsync(int userId);

    /// <summary>
    /// Validates adding a new Purchase
    /// </summary>
    /// <param name="purchaseAddDto">A DTO containing information about new Purchase</param>
    /// <exception cref="InvalidPurchaseException">User or Product was not found</exception>
    Task ValidateAddingAsync(PurchaseAddDto purchaseAddDto);
}