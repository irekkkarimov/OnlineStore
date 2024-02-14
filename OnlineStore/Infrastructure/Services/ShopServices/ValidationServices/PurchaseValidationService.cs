using Application.Abstractions.CustomExceptions.Abstractions.Purchase;
using Application.Abstractions.CustomExceptions.Products;
using Application.Abstractions.Services.ShopServices;
using Application.Abstractions.Services.ShopServices.ValidationServices;
using Application.DTOs.Purchase;
using Domain.Repositories;

namespace Infrastructure.Services.ShopServices.ValidationServices;

public class PurchaseValidationService : IPurchaseValidationService
{
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;

    public PurchaseValidationService(IUserRepository userRepository, IProductRepository productRepository)
    {
        _userRepository = userRepository;
        _productRepository = productRepository;
    }

    public async Task ValidateGettingByUserIdAsync(int userId)
    {
        await ValidateUserExistence(userId);
    }

    public async Task ValidateAddingAsync(PurchaseAddDto purchaseAddDto)
    {
        await ValidateUserExistence(purchaseAddDto.UserId);
        await ValidateProductExistence(purchaseAddDto.ProductId);
    }

    private async Task ValidateUserExistence(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null)
            throw new InvalidPurchaseException("User not found");
    }

    private async Task ValidateProductExistence(int productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        if (product is null)
            throw new InvalidProductException("Product not found");
    }
}