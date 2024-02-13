using Application.DTOs.CartItem;

namespace Application.Abstractions.Services.ShopServices;

public interface ICartItemValidationService
{
    Task ValidateGettingByUserIdAsync(int userId);
    Task ValidateAddingAsync(CartItemAddDto cartItemAddDto);
    Task ValidateRemoveByUserIdAsync(int userId);
}