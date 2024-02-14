using Application.Abstractions.CustomExceptions.CartItemExceptions;
using Application.Abstractions.Services.ShopServices;
using Application.Abstractions.Services.ShopServices.ValidationServices;
using Application.DTOs.CartItem;
using Domain.Repositories;

namespace Infrastructure.Services.ShopServices.ValidationServices;

public class CartItemValidationService : ICartItemValidationService
{
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;

    public CartItemValidationService(IUserRepository userRepository, IProductRepository productRepository)
    {
        _userRepository = userRepository;
        _productRepository = productRepository;
    }

    public async Task ValidateGettingByUserIdAsync(int userId)
    {
        await CheckIfUserExistsAsync(userId);
    }

    public async Task ValidateAddingAsync(CartItemAddDto cartItemAddDto)
    {
        await CheckIfUserExistsAsync(cartItemAddDto.UserId);
        await CheckIfProductExistsAsync(cartItemAddDto.ProductId);
    }

    public async Task ValidateRemoveByUserIdAsync(int userId)
    {
        await CheckIfUserExistsAsync(userId);
    }

    private async Task CheckIfUserExistsAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user is null)
            throw new InvalidCartItemException("Wrong user id");
    }

    private async Task CheckIfProductExistsAsync(int productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);

        if (product is null)
            throw new InvalidCartItemException("Wrong product id");
    }
}