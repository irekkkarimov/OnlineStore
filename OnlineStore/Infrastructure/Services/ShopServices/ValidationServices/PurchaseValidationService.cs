using Application.Abstractions.Services.ShopServices;
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

    public Task ValidateAddingAsync(PurchaseAddDto purchaseAddDto)
    {
        // TODO implement
        throw new NotImplementedException();
    }
}