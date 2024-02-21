using Application.Abstractions.CustomExceptions.CartItemExceptions;
using Application.DTOs.CartItem;

namespace Application.Abstractions.Services.ShopServices.ValidationServices;

public interface ICartItemValidationService
{
    /// <summary>
    /// Validates getting by UserId
    /// </summary>
    /// <param name="userId">id of User that CartItems belong to</param>
    /// <exception cref="InvalidCartItemException">User was not found</exception>
    Task ValidateGettingByUserIdAsync(int userId);
    
    /// <summary>
    /// Validates adding a new CarItem
    /// </summary>
    /// <param name="cartItemAddDto">A DTO containing information about new CartItem</param>
    /// <exception cref="InvalidCartItemException">User was not found</exception>
    Task ValidateAddingAsync(CartItemAddDto cartItemAddDto);
    
    /// <summary>
    /// Validates removing by UserId
    /// </summary>
    /// <param name="userId">id of User that CartItems belong to</param>
    /// <exception cref="InvalidCartItemException">User or Product was not found</exception>
    Task ValidateRemoveByUserIdAsync(int userId);
}